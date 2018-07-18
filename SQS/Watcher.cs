using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Collections.Generic;
using System.Linq;

namespace SQS
{
    public static class Watcher
    {

        public static IEnumerable<string> Poll(string accessKey, string secretKey, string attribute, int maxMessages, string url, int timeout, int wait)
        {
            var awsCreds = new BasicAWSCredentials(accessKey, secretKey);

            var sqs = new AmazonSQSClient(awsCreds, RegionEndpoint.EUWest1);

            var request = CreateSQSRequest(attribute, maxMessages, url, timeout, wait);

            var receivedMessages = sqs.ReceiveMessageAsync(request).Result;

            var messageStrings = receivedMessages.Messages.Select(x => x.Body);

            return messageStrings;
        }



        private static ReceiveMessageRequest CreateSQSRequest(List<string> attributes, int maxMessages, string queueURL, int timeout, int wait)
        {
            var request = new ReceiveMessageRequest
            {
                AttributeNames = attributes,
                MaxNumberOfMessages = maxMessages,
                QueueUrl = queueURL,
                VisibilityTimeout = timeout,
                WaitTimeSeconds = wait
            };

            return request;
        }

        private static ReceiveMessageRequest CreateSQSRequest(string attribute, int maxMessages, string queueURL, int timeout, int wait)
        {
            var request = new ReceiveMessageRequest
            {
                AttributeNames = new List<string>() { attribute },
                MaxNumberOfMessages = maxMessages,
                QueueUrl = queueURL,
                VisibilityTimeout = timeout,
                WaitTimeSeconds = wait
            };

            return request;
        }
    }
}
