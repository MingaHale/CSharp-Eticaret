using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class UrunlerController : Controller
    {
        private readonly IUnitOfWorks works;
        public UrunlerController(IUnitOfWorks _works)
        {
            works = _works;
        }

        public IActionResult Index()
        {
            return View(works.ProductsService.GetAll());
        }
        public IActionResult Insert()
        {
            ViewBag.Kategori = works.CategoriesService.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Insert(Products data, IFormFile Dosya)
        {
            if (Dosya != null)
            {
                string uzanti = Path.GetExtension(Dosya.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string ResimAdi = Guid.NewGuid() + uzanti; // Resimin yeni adı
                    string DosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{ResimAdi}");
                    using (var stream = new FileStream(DosyaYolu, FileMode.Create))
                    {
                        Dosya.CopyTo(stream);
                    }
                    data.ImagesName = ResimAdi;//SQL'deki Produc ts tablsoundaki sütuna gönderiyoruz.
                    works.ProductsService.Insert(data);
                    ViewBag.Message = works.ProductsService.SaveChanges();
                }
                else
                {
                    ViewBag.Error = "Jpg ve Jpeg uzantılı dosya seçmelisiniz.";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Resim seçiniz";
            }
            ViewBag.Kategori = works.CategoriesService.GetAll();
            return View();
        }

        
        [Route("/admin/Urunler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            ViewBag.Kategori = works.CategoriesService.GetAll();
            return View(works.ProductsService.GetById(x=> x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Urunler/Update/{Id}")]
        public IActionResult Update(int Id, Products data,IFormFile Dosya)
        {

            if (Dosya != null)
            {
                string uzanti = Path.GetExtension(Dosya.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string ResimAdi = Guid.NewGuid() + uzanti;
                    string DosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{ResimAdi}");
                    using (var Stream = new FileStream(DosyaYolu, FileMode.Create))
                    {
                        Dosya.CopyTo(Stream);
                    }
                    data.ImagesName = ResimAdi;
                    works.ProductsService.Update(data);
                }
                else
                {
                    ViewBag.Error = "Jpg ve Jpeg uzantılı dosya seçmelisiniz.";
                }
            }
            else
            {
                works.ProductsService.Update(data);
            }

            ViewBag.Message = works.ProductsService.SaveChanges();
            ViewBag.Kategori = works.CategoriesService.GetAll();
            return View(works.ProductsService.GetById(x=> x.Id == Id));
        }

        [Route("/admin/Urunler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            works.ProductsService.Delete(x=> x.Id == Id);
            TempData["Message"] = works.ProductsService.SaveChanges();
            return Redirect("/admin/Urunler");
        }
    }
}
