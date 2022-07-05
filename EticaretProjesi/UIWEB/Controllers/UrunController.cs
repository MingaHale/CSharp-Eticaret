using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUnitOfWorks works;

        public UrunController(IUnitOfWorks works)
        {
            this.works = works;
        }
        [Route("/Urun/{KategoriId}")]
        public IActionResult Index( int KategoriId)
        {
            return View(works.ProductsService.GetAll().Where(x=> x.CategoriesId == KategoriId));
        }
        [Route("/Urun/{UrunSeo}/{Id}")]
        public IActionResult UrunDetay(int Id)
        {
            ViewBag.Resimler = works.ProductsImagesService.GetAll().Where(x => x.ProductsId == Id);
            return View(works.ProductsService.GetById(x=> x.Id == Id));
        }
    }
}
