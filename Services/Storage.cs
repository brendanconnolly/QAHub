using LiteDB;

namespace QAHub.Services
{
    public class Storage
    {
        private static LiteDatabase instance;
        private const string Db = "QAHubData.db";

        public const string RegressionCollectionName = "regressionTasks";

        public const string ReleaseCollectionName = "releases";

        public const string supportIssueCollectionName = "supportIssues";


        public static LiteDatabase DataBase()
        {
            if (instance == null)
            {
                instance = new LiteDatabase(Db);
            }
            return instance;
        }
    }

}