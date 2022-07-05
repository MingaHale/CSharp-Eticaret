using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();

            return Redirect("/Admin/Login");
        }
    }
}
