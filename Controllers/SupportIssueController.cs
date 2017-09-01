using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using QAHub.Services;
using QAHub.Models;
using System.Threading.Tasks;

namespace QAHub.Controllers
{
    public class SupportIssueController : Controller
    {
        private ISupportIssueRepository _service;

        public SupportIssueController(ISupportIssueRepository repo)
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
        public IActionResult Create(SupportIssueModel taskModel)
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

        [ActionName("Edit")]
        public IActionResult Edit(int id)
        {
            var issue = _service.Get(id);
            return View(issue);
        }

        [ActionName("EditStatus")]
        public IActionResult UpdateStatus(int id)
        {
            var issue = _service.Get(id);
            ViewBag.TicketNumber = issue.TicketNumber;
            ViewBag.Description = issue.Description;
            return View();
        }

        [HttpPost, ActionName("EditStatus")]
        public IActionResult UpdateStatus(int id, string message)
        {
            _service.UpdateStatus(id, message);
            return RedirectToAction(nameof(Index));
        }
    }
}