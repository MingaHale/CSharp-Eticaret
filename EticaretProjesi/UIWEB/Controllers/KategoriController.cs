using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IUnitOfWorks works;

        public KategoriController(IUnitOfWorks works)
        {
            this.works = works;
        }
        [Route("/Kategori/{KategoriSeo}/{KategoriId}")]
        public IActionResult Index(int KategoriId)
        {
            var data = works.ProductsService.GetAll().Where(x => x.CategoriesId == KategoriId);
            return View(works.ProductsService.GetAll().Where(x => x.CategoriesId == KategoriId));
        }

        [HttpPost]
        [Route("/Kategori/{KategoriSeo}/{KategoriId}")]      
        public IActionResult Index(int KategoriId, string Filtre)
        {
            if (Filtre == "Az")
            {
                return View(works.ProductsService.GetAll().Where(x => x.CategoriesId == KategoriId).OrderBy(x=> x.Name));
            }
            else if (Filtre == "FiyatArtan")
            {
                return View(works.ProductsService.GetAll().Where(x => x.CategoriesId == KategoriId).OrderByDescending(x => x.Price));
            }
            else
            {
                return View(works.ProductsService.GetAll().Where(x => x.CategoriesId == KategoriId).OrderBy(x => x.Price));
            }

            
        }
    }
}
