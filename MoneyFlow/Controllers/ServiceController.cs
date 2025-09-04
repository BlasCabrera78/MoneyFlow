using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Context;
using MoneyFlow.Managers;
using MoneyFlow.Models;
using System.Security.Claims;

namespace MoneyFlow.Controllers
{
    [Authorize]
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var list = _serviceManager.GetAll(int.Parse(UserId));

            return View(list);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(ServiceVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            model.UserId = int.Parse(UserId);
            var response = _serviceManager.New(model);
            if (response == 1) return RedirectToAction("Index");

            ViewBag.message = "Error";
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ServiceVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = _serviceManager.Edit(model);
            if (response == 1) return RedirectToAction("Index");

            ViewBag.message = "Error";
            return View(model);
        }

        public IActionResult Delete(int id)  
        {
            var response = _serviceManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
