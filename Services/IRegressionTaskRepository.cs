using System.Collections.Generic;
using QAHub.Models;

namespace QAHub.Services
{

    public interface IRegressionTaskRepository
    {
        IEnumerable<RegressionTaskModel> FetchAll();

        void Add(RegressionTaskModel taskModel);

        void Delete(int id);
    }
}