using Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Jira
{
    public static class JiraClient
    {
        public static JiraIssue GetIssue(string url, string authenticationKey)
        {

            var client = CreateHttpClientWithAuthorization("Basic", authenticationKey);
            var reponse = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<JiraIssue>(reponse);
        }

        /// <summary>
        /// Validates user input to ensure the "IMC-" prefix is present
        /// </summary>
        /// <param name="keyNumber">Jira issue key provided by the user</param>
        /// <returns>Valid IMC Jira key</returns>
        public static string AppendPrefixIfMissing(string prefix, string keyNumber)
        {
            var startingIndexOfNumber = keyNumber.IndexOfAny("0123456789".ToCharArray());
            var number = keyNumber.Substring(startingIndexOfNumber, keyNumber.Length - startingIndexOfNumber);

            return prefix + number;
        }

        #region Jira API
        /*
            ("rest/api/2/search?jql=sprint+in+(openSprints())+AND+project+in+(IMC)+AND+issuetype+in+(Bug,+Epic,+Story)", Method.GET);
        */
        #endregion

        private static HttpClient CreateHttpClientWithAuthorization(string authType, string authKey)
        {
            var retVal = new HttpClient();

            retVal.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType, authKey);

            return retVal;
        }
    }
}
