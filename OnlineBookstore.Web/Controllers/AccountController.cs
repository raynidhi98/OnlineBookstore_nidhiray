using Microsoft.AspNetCore.Mvc;

namespace OnlineBookstore.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(); // Ensure Views/Account/Login.cshtml exists
        }

        public IActionResult Register()
        {
            return View(); // Ensure Views/Account/Register.cshtml exists
        }
    }
}
