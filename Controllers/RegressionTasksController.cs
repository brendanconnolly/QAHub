using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using QAHub.Services;
using QAHub.Models;
using System.Threading.Tasks;

namespace QAHub.Controllers
{
    public class RegressionTasksController : Controller
    {

        public IActionResult Index()
        {
            var service = new RegressionTaskService();
            return View(service.FetchAll());
        }
    }
}