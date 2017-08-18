using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace QAHub.Controllers
{
    public class RegressionTasksController:Controller
    {
        public string Index()
        {
            return "I'm Mongo";
        }
    }
}