using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LiteDB;

namespace QAHub.Models
{
    public class SupportIssueModel
    {
        public SupportIssueModel()
        {
            Status = new List<SupportIssueStatusModel>();
            Resolution = new SupportIssueResolutionModel();

        }

        [BsonId]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TicketNumber { get; set; }

        [Required]
        public string Version { get; set; }

        [Required]
        [StringLength(100)]
        public string Area { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }


        public string QAOwner { get; set; }

        [Required]
        public string SupportOwner { get; set; }

        public bool InitiallyRejected { get; set; }

        public DateTime EscalatedOn { get; set; }

        public DateTime? DeEscalatedOn { get; set; }

        public bool IsClosed { get { return DeEscalatedOn != null; } }

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
        [DataType(DataType.MultilineText)]
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