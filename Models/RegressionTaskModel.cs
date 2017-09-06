
using LiteDB;

namespace QAHub.Models
{
    public class RegressionTaskModel
    {
        [BsonId]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string Notes { get; set; }

        public int TeamNumber { get; set; }

        public string Tester { get; set; }

        public bool IncludeInRelease { get; set; }
    }
}