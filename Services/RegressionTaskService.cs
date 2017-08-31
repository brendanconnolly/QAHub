using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAHub.Models;

namespace QAHub.Services
{

    public class RegressionTaskService : IRegressionTaskRepository
    {
        private List<RegressionTaskModel> _regression;

        public RegressionTaskService()
        {
            _regression = new List<RegressionTaskModel>();

            _regression.Add(new RegressionTaskModel()
            {
                Id = 1,
                Category = "Credit Card 2.x",
                Title = "Shift4",
                Tester = "Anne"
            });

            _regression.Add(new RegressionTaskModel()
            {
                Id = 2,
                Category = "Gift Card 2.x",
                Title = "Agilysys (Visual One/LMS)",
                Tester = "Jeff"
            });


        }

        public IEnumerable<RegressionTaskModel> FetchAll()
        {
            return _regression;
        }

        public void Add(RegressionTaskModel taskModel)
        {

            _regression.Add(taskModel);
        }

        public void Delete(int id)
        {
            _regression = _regression.Where(x => x.Id != id).ToList();
        }

    }
}