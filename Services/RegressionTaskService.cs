using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using QAHub.Models;

namespace QAHub.Services
{

    public class RegressionTaskService : IRegressionTaskRepository
    {
        private LiteCollection<RegressionTaskModel> _regression;

        public RegressionTaskService()
        {
            using (var db = Storage.DataBase())
            {
                _regression = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);

                // if (_regression.Count() == 0)
                // {
                //     InitializeCollection();
                // }

            }

        }



        public IEnumerable<RegressionTaskModel> FetchAll()
        {
            using (var db = Storage.DataBase())
            {
                var collection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);
                return collection.FindAll().ToList();

            }
        }

        public void Add(RegressionTaskModel taskModel)
        {

            using (var db = Storage.DataBase())
            {
                var regressionTaskCollection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);

                regressionTaskCollection.Insert(taskModel);

            }
        }

        public void Delete(int id)
        {
            using (var db = Storage.DataBase())
            {
                var regressionTaskCollection = db.GetCollection<RegressionTaskModel>(Storage.RegressionCollectionName);

                regressionTaskCollection.Delete(id);

            }
        }

    }
}