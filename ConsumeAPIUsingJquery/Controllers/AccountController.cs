using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPIUsingJquery.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }      
    }
}
