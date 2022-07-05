using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWEB.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IUnitOfWorks works;
        public MusteriController(IUnitOfWorks works)
        {
            this.works = works;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var BulunanMusteri = works.CustomerService.GetById(x => x.Email == email &&  x.Passwords == password);
            if (BulunanMusteri != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,BulunanMusteri.NameSurname),
                new Claim("Id",BulunanMusteri.Id.ToString()),
            };
                var UserIdentity = new ClaimsIdentity(claims, "MusteriLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
                HttpContext.SignInAsync(principal);
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }
        }

        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UyeOl(Customers data)
        {
            //Kullanıcı kayıt olduğunda otomatik giriş yapsın.
            works.CustomerService.Insert(data);
            works.CustomerService.SaveChanges();

            var BulunanMusteri = works.CustomerService.GetById(x => x.Email == data.Email && x.Phone == data.Phone && x.Passwords == data.Passwords);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,BulunanMusteri.NameSurname),
                new Claim("Id",BulunanMusteri.Id.ToString()),
            };
            var UserIdentity = new ClaimsIdentity(claims, "MusteriLogin");
            ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);
            HttpContext.SignInAsync(principal);
            return Redirect("/");
        }

    }
}
