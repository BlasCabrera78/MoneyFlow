using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class AccountController(UserManager _userManager): Controller
    {
        public IActionResult Login()
        {
            var viewModel = new LoginVM();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var found = _userManager.Login(viewModel);
            if (found.UserId == 0)
            {
                ViewBag.Message = "No matches found";
                return View();
            }

            else 
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Register() 
        {
            var viewModel = new UserVM();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(UserVM viewModel) 
        {
            if (!ModelState.IsValid) return View(viewModel);

            try
            {
                var response = _userManager.Register(viewModel);

                if (response != 0)
                {
                    ViewBag.message = "Your account is alredy registered";
                    ViewBag.Class = "Alert-succes";
                }
                else 
                {
                    ViewBag.message = "Your account could not be registered";
                    ViewBag.Class = "Alert-danger";
                }
            }
            catch (Exception ex) 
            {
                ViewBag.message = ex.Message;
                ViewBag.Class = "Alert-danger";
            }

            return View();
        }
    }
}
