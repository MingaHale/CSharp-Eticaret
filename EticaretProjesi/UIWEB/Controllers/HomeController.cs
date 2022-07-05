using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorks works;

        public HomeController(IUnitOfWorks works)
        {
            this.works = works;
        }
        public IActionResult Index()
        {
            return View(works.ProductsService.GetAll());
        }
    }
}
