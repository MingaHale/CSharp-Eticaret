using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class MusterilerController : Controller
    {
        private readonly IUnitOfWorks works;

        public MusterilerController(IUnitOfWorks _works)
        {
            works =_works;
        }
        public IActionResult Index()
        {
            return View(works.CustomerService.GetAll());
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Customers data)
        {
            works.CustomerService.Insert(data);
            ViewBag.Message = works.CustomerService.SaveChanges();
            return View();
        }

        [Route("/admin/Musteriler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(works.CustomerService.GetById(x=> x.Id ==Id));
        }
        [HttpPost]
        [Route("/admin/Musteriler/Update/{Id}")]
        public IActionResult Update(int Id,Customers data)
        {
            works.CustomerService.Update(data);
            ViewBag.Message = works.CustomerService.SaveChanges();
            return View(works.CustomerService.GetById(x => x.Id == Id));
        }
        [Route("/admin/Musteriler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            works.CustomerService.Delete(x => x.Id == Id);
            TempData["Message"] = works.CustomerService.SaveChanges();
            return Redirect("/admin/Musteriler");
        }
    }
}
