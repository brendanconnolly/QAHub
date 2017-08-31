using System.Collections.Generic;
using QAHub.Models;

namespace QAHub.Services
{

    public interface ISupportIssueRepository
    {
        IEnumerable<SupportIssueModel> FetchAll();

        SupportIssueModel Get(int id);

        void Add(SupportIssueModel taskModel);

        void Delete(int id);

        void UpdateStatus(int id, string message);
    }
}