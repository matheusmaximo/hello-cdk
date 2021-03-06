using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelloCdkConsumerLambda
{
    public class Function
    {
        /// <summary>
        /// A simple function
        /// </summary>
        /// <param name="sqsEvent"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
        {
            context.Logger.LogLine($"{sqsEvent.Records.Count} messages arrived.");
            foreach (var message in sqsEvent.Records)
            {
                context.Logger.LogLine(message.Body);
            }
        }
    }
}
