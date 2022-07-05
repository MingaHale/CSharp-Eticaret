using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Email, string Sifre)
        {
            if (Email == "melike@hale.com" && Sifre == "123Mm*")
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Melike Hale Minga"),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var UserIdentity = new ClaimsIdentity(Claims, "LoginInformation");
                ClaimsPrincipal  principal = new ClaimsPrincipal(UserIdentity);
                HttpContext.SignInAsync(principal);
                return Redirect("/admin/Kategoriler");
            }
            else
            {
                ViewBag.Error = "Email Adresinizi veya Şifrenizi Kontrol Ediniz";
                return View();
            }
            //Authentication = Kullanıcınınn sistemde var olup olmadığını pptmatik sorgulayan ve on Göre işlem yaptıran mekanizmadır.
            //Authorize = sisteme giriş yapan kullanıcının yetkisini kontrol eden ve ona göre işlme yaptıran mekanizmadır.
            //Claims = Sistme giriş yapan kullanıcının bilgilerini tutmamızı sağlayan mekanizmadır.
            //Claims ıdentity = kullanılan claimsleri gruplandırmamızı sağlayan sınıf yapısıdır.
  
        }
    }
}
