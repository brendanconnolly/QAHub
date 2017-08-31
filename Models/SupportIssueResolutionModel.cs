namespace QAHub.Models
{
    public enum SupportIssueResolutionType
    {
        Bug,
        ExistingFixNotApplied,
        Limitation,
        ConfigurationOrTraining,
        UnsupportedOrUnCertified,
        ThirdPartyIssue,
        ReprocessData,
        DataBaseIssue,
        UpgradeProblem,
        HotFixNotInstalledCorrectly,
        UnableToDuplicate,
        Other
    }
    public class SupportIssueResolutionModel
    {
        public SupportIssueResolutionType Category { get; set; }
        public bool IsNewBug { get; set; }
        public int BugNumber { get; set; }
    }
}