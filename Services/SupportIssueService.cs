using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
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
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                collection.Insert(taskModel);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                collection.Delete(id);
            }
        }

        public IEnumerable<SupportIssueModel> FetchAll()
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.FindAll().ToList();
            }
        }

        public SupportIssueModel Get(int id)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.FindById(id);
            }
        }

        public void UpdateStatus(int id, string message)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                var issue = collection.FindById(id);
                issue.Status.Add(new SupportIssueStatusModel(message));
                collection.Update(issue);
            }
        }

        public void ResolveIssue(int id, SupportIssueResolutionModel model)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                var issue = collection.FindById(id);
                issue.Resolution = model;
                issue.Status.Add(new SupportIssueStatusModel(model.ClosingRemarks));
                issue.DeEscalatedOn = DateTime.Now;
                collection.Update(issue);
            }

        }

        public IEnumerable<SupportIssueModel> FetchOpenIssues()
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.Find(x => !x.IsClosed).ToList();
            }
        }

        public IEnumerable<SupportIssueModel> FetchClosedIssues()
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<SupportIssueModel>(Storage.supportIssueCollectionName);
                return collection.Find(x => x.IsClosed).ToList();
            }
        }
    }
}