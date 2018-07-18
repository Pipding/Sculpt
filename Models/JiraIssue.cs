using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    public class JiraIssue
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("fields")]
        public JiraIssueFields Fields { get; set; }
    }

    #region DTO bullshit

    public class JiraIssueFields
    {
        [JsonProperty("assignee")]
        public JiraIssueAssignee Assignee { get; set; }

        [JsonProperty("issuetype")]
        public JiraIssueType Issue { get; set; }

        [JsonProperty("fixVersions")]
        public List<JiraFixVersion> Releases { get; set; }

        [JsonProperty("customfield_10700")]
        public JiraProjectName Project { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }

    public class JiraIssueAssignee
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class JiraIssueType
    {
        [JsonProperty("name")]
        public string Type { get; set; }
    }

    public class JiraFixVersion
    {
        [JsonProperty("name")]
        public string Version { get; set; }
    }

    public class JiraProjectName
    {
        [JsonProperty("value")]
        public string Name { get; set; }
    }

    #endregion

}
