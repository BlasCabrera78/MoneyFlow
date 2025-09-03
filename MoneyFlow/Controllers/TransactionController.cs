using Microsoft.AspNetCore.Mvc;
using MoneyFlow.DTOs;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class TransactionController(
        ServiceManager _serviceManager,
        TransactionManager _transactionManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ServiceByType(string typeService)
        {
            var userId = 1;
            var services = _serviceManager.GetByType(userId, typeService);
            return Ok(services);
        }

        [HttpPost]
        public IActionResult New([FromBody] TransactionDTO modelDto)
        {
            modelDto.UserId = 1;
            var response = _transactionManager.New(modelDto);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult HistoryTransaction(DateOnly startDate, DateOnly EndDate, int UserId)
        {
            var userId = 1;
            var list = _transactionManager.GetHistorial(startDate, EndDate, userId);
            return Ok(new {data = list });
        }

        public IActionResult History() 
        {
            return View();
        }
    }
}
