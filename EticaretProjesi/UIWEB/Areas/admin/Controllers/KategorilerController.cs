using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    //Eğer oluşturulan controller'lar areas klasörü içerisinde ise bunların sahibinin areas olduğunu belirtmek zorundayız.
    [Area("admin"), Authorize]//=> Areas klasörü içerisindeki admin klasöründedir
    public class KategorilerController : Controller
    {
        private readonly IUnitOfWorks unitOfWorks;
        public KategorilerController(IUnitOfWorks _unitOfWorks)
        {
            unitOfWorks = _unitOfWorks;
        }
        public IActionResult Index()
        {
            return View(unitOfWorks.CategoriesService.GetAll());
        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Categories data)
        {
            unitOfWorks.CategoriesService.Insert(data);
            ViewBag.Message = unitOfWorks.CategoriesService.SaveChanges();
            return View();
        }

        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(unitOfWorks.CategoriesService.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id, Categories data)
        {
            unitOfWorks.CategoriesService.Update(data);
            ViewBag.Massage = unitOfWorks.CategoriesService.SaveChanges();
            return View(unitOfWorks.CategoriesService.GetById(x => x.Id == Id));
        }


        [Route("/admin/Kategoriler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            unitOfWorks.CategoriesService.Delete(x=> x.Id == Id);
            TempData["Message"] = unitOfWorks.CategoriesService.SaveChanges();
            //TempData = A ActionResult'tan B ActionResult'a Data aktarmamızı sağlayan yapıdır.

            return Redirect("/admin/Kategoriler");
        }
    }
}
