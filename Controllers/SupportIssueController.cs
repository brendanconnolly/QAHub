using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using QAHub.Services;
using QAHub.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

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
            return View(_service.FetchOpenIssues());
        }

        [ActionName("ClosedIssues")]
        public IActionResult ClosedIssues()
        {
            return View(_service.FetchClosedIssues());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(SupportIssueModel taskModel)
        {


            ModelState["Resolution.ClosingRemarks"].Errors.Clear();

            //no resolution on new support issue
            var resolutions = ModelState.Where(x => x.Key.Contains("Resolution"));
            foreach (var x in resolutions)
            {
                ModelState.Remove(x.Key);
            }

            if (ModelState.IsValid)
            {
                taskModel.EscalatedOn = DateTime.Now;
                _service.Add(taskModel);
                return RedirectToAction(nameof(Index));
            }

            return View(taskModel);

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
        public IActionResult UpdateStatus(int id, SupportIssueStatusModel model)
        {

            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                _service.UpdateStatus(id, model.Message);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [ActionName("EditResolve")]
        public IActionResult ResolveIssue(int id)
        {
            var issue = _service.Get(id);
            ViewBag.TicketNumber = issue.TicketNumber;
            ViewBag.Description = issue.Description;
            return View();
        }

        [HttpPost, ActionName("EditResolve")]
        public IActionResult ResolveIssue(int id, SupportIssueResolutionModel model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                _service.ResolveIssue(id, model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);


        }
    }
}