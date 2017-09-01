using System.Collections.Generic;
using QAHub.Models;

namespace QAHub.Services
{

    public interface IReleaseRepository
    {
        IEnumerable<ReleaseModel> FetchAll();

        ReleaseModel Get(int id);

        void Add(ReleaseModel taskModel);

        void Delete(int id);
    }
}