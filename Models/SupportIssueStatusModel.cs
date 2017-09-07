using System;
using System.ComponentModel.DataAnnotations;

namespace QAHub.Models
{

    public class SupportIssueStatusModel
    {
        public SupportIssueStatusModel(string message)
        {
            Date = DateTime.Now;
            Message = message;
        }

        public SupportIssueStatusModel()
        {

        }
        public DateTime Date { get; set; }

        [Required]
        public string Message { get; set; }

    }
}