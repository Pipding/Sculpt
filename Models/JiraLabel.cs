namespace Models
{
    public class JiraLabel
    {
        public string IssueType { get; set; }
        public string Key { get; set; }
        public string Assignee { get; set; }
        public string Summary1 { get; set; }
        public string Summary2 { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string LinkedIssue { get; set; }
        public string Estimate { get; set; }
    }
}
