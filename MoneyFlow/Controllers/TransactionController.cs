using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.DTOs;
using MoneyFlow.Managers;
using MoneyFlow.Models;
using System.Security.Claims;

namespace MoneyFlow.Controllers
{
    [Authorize]
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
            var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var services = _serviceManager.GetByType(int.Parse(UserId), typeService);
            return Ok(services);
        }

        [HttpPost]
        public IActionResult New([FromBody] TransactionDTO modelDto)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            modelDto.UserId = int.Parse(userId);
            var response = _transactionManager.New(modelDto);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult HistoryTransaction(DateOnly startDate, DateOnly EndDate, int UserId)
        {
            var User_Id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userId = int.Parse(User_Id);
            var list = _transactionManager.GetHistorial(startDate, EndDate, userId);
            return Ok(new {data = list });
        }

        public IActionResult History() 
        {
            return View();
        }
    }
}
