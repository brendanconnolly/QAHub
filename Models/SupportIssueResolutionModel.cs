using System.ComponentModel.DataAnnotations;

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
        [Required]
        public SupportIssueResolutionType Category { get; set; }
        public bool IsNewBug { get; set; }
        public int BugNumber { get; set; }

        [Required]
        public string ClosingRemarks { get; set; }
    }
}