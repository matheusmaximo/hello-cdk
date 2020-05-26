using Amazon.CDK;
using Amazon.CDK.AWS.IAM;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;

namespace HelloCdk
{
    public class HelloStack : Stack
    {
        public HelloStack(Construct parent, string id, IStackProps props) : base(parent, id, props)
        {
            var topic = new Topic(this, "HelloCdkTopic", new TopicProps
            {
                TopicName = "HelloCdkTopic",
                DisplayName = "My First Topic From HelloCdk"
            });

            var queue = new Queue(this, "HelloCdkQueue", new QueueProps
            {
                QueueName = "HelloCdkQueue"
            });
            topic.AddSubscription(new SqsSubscription(queue, new SqsSubscriptionProps
            {
                RawMessageDelivery = true
            }));

            var functionType = typeof(HelloCdkConsumerLambda.Function);
            var function = new Function(this, nameof(HelloCdkConsumerLambda), new FunctionProps
            {
                Code = Code.FromAsset($"./src/{nameof(HelloCdkConsumerLambda)}/bin/Release/netcoreapp2.1/publish"),
                Runtime = Runtime.DOTNET_CORE_2_1,
                Tracing = Tracing.ACTIVE,
                Handler = $"{functionType.Assembly.GetName().Name}::{functionType}::{nameof(HelloCdkConsumerLambda.Function.FunctionHandler)}",
                MemorySize = 256,
                Timeout = Duration.Seconds(10)
            });
            function.AddToRolePolicy(new PolicyStatement(new PolicyStatementProps
            {
                Actions = new[] { "sqs:ReceiveMessage", "sqs:DeleteMessage", "sqs:GetQueueAttributes", "sqs:ChangeMessageVisibility" },
                Resources = new[] { queue.QueueArn }
            }));

            _ = new EventSourceMapping(this, $"{nameof(HelloCdkConsumerLambda)}Trigger", new EventSourceMappingProps
            {
                EventSourceArn = queue.QueueArn,
                BatchSize = 10,
                Enabled = true,
                Target = function
            });
        }
    }
}