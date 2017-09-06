using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using QAHub.Models;

namespace QAHub.Services
{

    public class ReleaseService : IReleaseRepository
    {
        private IRegressionTaskRepository _regressionRepo;
        public ReleaseService(IRegressionTaskRepository regressionRepo)
        {
            _regressionRepo = regressionRepo;

        }

        public ReleaseModel Get(int id)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<ReleaseModel>(Storage.ReleaseCollectionName);
                return collection.FindById(id);
            }
        }
        public IEnumerable<ReleaseModel> FetchAll()
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<ReleaseModel>(Storage.ReleaseCollectionName);

                return collection.FindAll().ToList();
            }

        }

        public void Add(ReleaseModel taskModel)
        {
            taskModel.RegressionTasks = _regressionRepo.FetchAll();
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<ReleaseModel>(Storage.ReleaseCollectionName);
                collection.Insert(taskModel);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<ReleaseModel>(Storage.ReleaseCollectionName);
                collection.Delete(id);
            }
        }

    }
}