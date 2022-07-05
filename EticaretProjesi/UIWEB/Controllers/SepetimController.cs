using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Controllers
{
    public class SepetimController : Controller
    {
        private readonly IUnitOfWorks works;

        public SepetimController(IUnitOfWorks works)
        {
            this.works = works;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["SepetId"] != null)
            {
                int Coockies = int.Parse(Request.Cookies["SepetId"].ToString());
                return View(works.TemporaryService.GetAll().Where(x => x.BasketCookies == Coockies));
            }
            else
            {
                ViewBag.Error = "Sepetinizde Ürün Bulunmamaktadır";
                return View();
            }
            
        }
    }
}
