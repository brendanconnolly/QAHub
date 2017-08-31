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
        private IRegressionTaskRepository _service;

        public RegressionTasksController(IRegressionTaskRepository repo)
        {
            _service = repo;
        }

        public IActionResult Index()
        {
            return View(_service.FetchAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(RegressionTaskModel taskModel)
        {
            _service.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}