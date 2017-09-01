using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAHub.Models;

namespace QAHub.Services
{

    public class ReleaseService : IReleaseRepository
    {
        private List<ReleaseModel> _release;

        public ReleaseService()
        {
            _release = new List<ReleaseModel>();

            _release.Add(new ReleaseModel()
            {
                Id = 1,
                Version = "4.5.0",

            });




        }

        public ReleaseModel Get(int id)
        {
            return _release.First(x => x.Id == id);
        }
        public IEnumerable<ReleaseModel> FetchAll()
        {
            return _release;
        }

        public void Add(ReleaseModel taskModel)
        {

            _release.Add(taskModel);
        }

        public void Delete(int id)
        {
            _release = _release.Where(x => x.Id != id).ToList();
        }

    }
}