using System.Collections.Generic;
using System.Linq;
using QAHub.Models;

namespace QAHub.Services
{

    public class SupportIssueService : ISupportIssueRepository
    {

        private List<SupportIssueModel> _repo;

        public SupportIssueService()
        {
            _repo = new List<SupportIssueModel>();
            _repo.Add(new SupportIssueModel()
            {
                Area = "Everywhere",
                TicketNumber = 1,
                Version = "4.5.0",
                InitiallyRejected = true
            });
        }
        public void Add(SupportIssueModel taskModel)
        {
            _repo.Add(taskModel);
        }

        public void Delete(int id)
        {
            _repo = _repo.Where(x => x.Id != id).ToList();
        }

        public IEnumerable<SupportIssueModel> FetchAll()
        {
            return _repo;
        }

        public SupportIssueModel Get(int id)
        {
            return _repo.First(x => x.Id == id);
        }

        public void UpdateStatus(int id, string message)
        {
            _repo.First(x => x.Id == id).Status.Add(new SupportIssueStatusModel(message));
        }
    }
}