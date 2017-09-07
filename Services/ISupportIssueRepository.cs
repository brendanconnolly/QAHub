using System.Collections.Generic;
using QAHub.Models;

namespace QAHub.Services
{

    public interface ISupportIssueRepository
    {
        IEnumerable<SupportIssueModel> FetchAll();

        IEnumerable<SupportIssueModel> FetchOpenIssues();

        IEnumerable<SupportIssueModel> FetchClosedIssues();

        SupportIssueModel Get(int id);

        void Add(SupportIssueModel taskModel);

        void Delete(int id);

        void UpdateStatus(int id, string message);

        void ResolveIssue(int id, SupportIssueResolutionModel model);
    }
}