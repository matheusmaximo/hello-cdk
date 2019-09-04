using Amazon.CDK;

namespace HelloCdk
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var app = new App(null);

            _ = new HelloStack(app, nameof(HelloCdk), new StackProps());

            app.Synth();
        }
    }
}
