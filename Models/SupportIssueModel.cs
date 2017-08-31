using System;
using System.Collections.Generic;
using System.Linq;

namespace QAHub.Models
{
    public class SupportIssueModel
    {
        public SupportIssueModel()
        {
            Status = new List<SupportIssueStatusModel>();
            Resolution = new SupportIssueResolutionModel();

        }
        public int Id { get; set; }
        public int TicketNumber { get; set; }

        public string Version { get; set; }

        public string Area { get; set; }
        public string Description { get; set; }

        public string QAOwner { get; set; }

        public string SupportOwner { get; set; }

        public bool InitiallyRejected { get; set; }

        public DateTime EscalatedOn { get; set; }

        public DateTime DeEscalatedOn { get; set; }

        public DateTime? Updated
        {
            get
            {
                if (Status.Count > 0)
                {
                    DateTime? date = Status?.Last()?.Date;
                    return date == default(DateTime) ? null : date;
                }
                return null;
            }
        }
        public string LatestUpdate
        {
            get
            {
                if (Status.Count > 0)
                {
                    return Status?.Last()?.Message ?? "";
                }
                return "";
            }
        }



        public SupportIssueResolutionModel Resolution { get; set; }
        public List<SupportIssueStatusModel> Status { get; set; }
    }
}