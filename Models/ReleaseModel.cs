using System.Collections.Generic;
using LiteDB;

namespace QAHub.Models
{

    public class ReleaseModel
    {
        public ReleaseModel()
        {
            RegressionTasks = new List<RegressionTaskModel>();
        }
        [BsonId]
        public int Id { get; set; }
        public string Version { get; set; }
        public IEnumerable<RegressionTaskModel> RegressionTasks { get; set; }

    }
}