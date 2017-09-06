using System.Collections.Generic;
using System.Linq;
using QAHub.Models;

namespace QAHub.Services
{

    public class SupportIssueService : ISupportIssueRepository
    {



        public SupportIssueService()
        {

        }
        public void Add(SupportIssueModel taskModel)
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                collection.Insert(taskModel);
            }
        }

        public void Delete(int id)
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                collection.Delete(id);
            }
        }

        public IEnumerable<SupportIssueModel> FetchAll()
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.FindAll().ToList();
            }
        }

        public SupportIssueModel Get(int id)
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.FindById(id);
            }
        }

        public void UpdateStatus(int id, string message)
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                var issue = collection.FindById(id);
                issue.Status.Add(new SupportIssueStatusModel(message));
            }
        }
    }
}