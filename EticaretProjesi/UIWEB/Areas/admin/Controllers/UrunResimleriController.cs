using Bussiness.Abstract;
using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class UrunResimleriController : Controller
    {
        private readonly IUnitOfWorks works;

        public UrunResimleriController(IUnitOfWorks _works)
        {
            works = _works;
        }

        [HttpGet]
        [Route("/Admin/UrunResimleri/list/{UrunId}")]
        public IActionResult Index(int UrunId)
        {
            return View(works.ProductsImagesService.GetAll().Where(x => x.ProductsId == UrunId));
        }

        [HttpPost]
        [Route("/Admin/UrunResimleri/list/{UrunId}")]
        public IActionResult Index(int UrunId,IFormFile dosya)
        {
            if (dosya != null)
            {
                string uzanti = Path.GetExtension(dosya.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string RandomName = Guid.NewGuid() + uzanti;

                    string DosyaKayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RandomName}");
                    using (var stream = new FileStream(DosyaKayitYolu, FileMode.Create))
                    {
                        dosya.CopyTo(stream);
                    }
                    ProductsImages p = new ProductsImages();
                    p.Images = RandomName;
                    p.ProductsId = UrunId;
                    works.ProductsImagesService.Insert(p);
                    works.ProductsImagesService.SaveChanges();


                }
            }
            return View(works.ProductsImagesService.GetAll().Where(x => x.ProductsId == UrunId));
        }

        [HttpGet]
        [Route("/Admin/UrunResimleri/Delete/{ResimId}")]
        public IActionResult Delete(int ResimId)
        {
            var data = works.ProductsImagesService.GetById(x=> x.Id == ResimId);
            works.ProductsImagesService.Delete(x => x.Id == ResimId);
            works.ProductsImagesService.SaveChanges();
            return Redirect("/Admin/UrunResimleri/list/"+ data.ProductsId+"");
        }
    }
}
