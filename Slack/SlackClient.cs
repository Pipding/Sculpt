using Slack.Webhooks;
using System.Collections.Generic;

namespace Slack
{
    public static class SlackClient
    {

        public static bool PostMessage(string webhook, string message, IEnumerable<string> channels)
        {
            var client = new Webhooks.SlackClient(webhook);

            var msg = ConvertToSlackMessage(message);

            return client.PostToChannels(msg, channels);
        }

        private static SlackMessage ConvertToSlackMessage(string message)
        {
            return new SlackMessage { Text = message };
        }
    }
}
