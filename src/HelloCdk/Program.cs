using Amazon.CDK;

namespace HelloCdk
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var app = new App(null);

            // A CDK app can contain multiple stacks. You can view a list of all the stacks in your
            // app by typing `cdk list`.
            _ = new HelloStack(app, "hello-cdk-1", new StackProps());

            app.Synth();
        }
    }
}
