using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Context;
using MoneyFlow.Managers;

namespace MoneyFlow.Controllers
{
    public class ServiceController(ServiceManager _serviceManager) : Controller
    {
        public IActionResult Index()
        {
            
            var list = _serviceManager.GetAll(1); 

            return View(list);
        }
    }
}
