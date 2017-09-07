using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using QAHub.Models;

namespace QAHub.Services
{

    public class RegressionTaskService : IRegressionTaskRepository
    {


        public RegressionTaskService()
        {


        }



        public IEnumerable<RegressionTaskModel> FetchAll()
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var collection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);
                return collection.FindAll().OrderBy(x => x.Category).ThenBy(t => t.Title).ToList();

            }
        }

        public void Add(RegressionTaskModel taskModel)
        {

            using (var db = new LiteDatabase(Storage.Db))
            {
                var regressionTaskCollection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);

                regressionTaskCollection.Insert(taskModel);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(Storage.Db))
            {
                var regressionTaskCollection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);

                regressionTaskCollection.Delete(id);

            }
        }

    }
}