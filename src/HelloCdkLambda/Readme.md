# My First CDK Project

## What is this project for?

I'm trying to use AWS CDK for .Net Core.
This is a small Proof of Concept

## How to deploy it?

Install CDK:

`npm i -g aws-cdk`

Deploy CDK Toolkit

`cdk bootstrap`

On the root of this project, publish the Lambda project

`dotnet publish .\src\HelloCdkLambda\HelloCdkLambda.csproj -c Release`

On the root of this project, build the stack

`dotnet build .\src\HelloCdk\HelloCdk.csproj`

Run Cdk Synthetise to see the template

`cdk synthesize`

Deploy the stack

`cdk deploy`

If asked, type Y and press enter, to confirm the permission changes

## What is in this project

It creates a SNS Topic called HelloCdk_Topic. When a message is sent to this topic, it will be forwarded to a SQS queue.
It creates a SQS Queue called HelloCdk_Queue. When a message is sent to this queue, it will be delivered to a Lambda function.
It creates a Lambda function called hello-cdk-1-MyFirstFunction. When a SQS message is delivered, this Lambda will record the content of message Body to CloudWatch logs.

