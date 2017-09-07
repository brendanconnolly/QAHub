using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using QAHub.Services;
using QAHub.Models;
using System.Threading.Tasks;

namespace QAHub.Controllers
{
    public class ReleasesController : Controller
    {
        private IRegressionTaskRepository _regression;
        private IReleaseRepository _release;

        public ReleasesController(IReleaseRepository releaseRepo, IRegressionTaskRepository regressionRepo)
        {
            _regression = regressionRepo;
            _release = releaseRepo;
        }

        [ActionName("Detail")]
        public IActionResult Get(int id)
        {
            var release = _release.Get(id);
            return View(release);
        }

        public IActionResult Index()
        {
            return View(_release.FetchAll());
        }


        [ActionName("Details")]
        public IActionResult ReleaseDetail(int id)
        {
            var rel = _release.Get(id);
            return View(rel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(ReleaseModel taskModel)
        {
            _release.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("EditRegressionAssignments")]
        public IActionResult EditRegressionAssignments(int id)
        {
            var rel = _release.Get(id);
            ViewBag.Tasks = rel.RegressionTasks;
            return View(rel);
        }

        [HttpPut, ActionName("Edit")]
        public IActionResult Edit(ReleaseModel taskModel)
        {
            Delete(taskModel.Id);
            _release.Add(taskModel);
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _release.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}