using System.Collections.Generic;

namespace QAHub.Models
{

    public class ReleaseModel
    {
        public string Version { get; set; }
        public IEnumerable<RegressionTaskModel> RegressionTasks { get; set; }

    }
}