using Bussiness.Abstract;
using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SiparislerController : Controller
    {
        private readonly IUnitOfWorks works;
       

        public SiparislerController(IUnitOfWorks _works)
        {
            works = _works;
        }
    
        public IActionResult Index()
        {
            return View(works.OrdersService.GetAll());
        }

        [HttpPost]
        public IActionResult Index( string TariheGore, string DurumaGore)
        {
            var data = works.OrdersService.GetAll();
            IList<Orders> Filtrelenmis = new List<Orders>();


            if (TariheGore != "" && DurumaGore != "0")
            {
                foreach (var item in data)
                {
                    if (item.OrdersStatus == DurumaGore && item.PaymentDate.ToString("yyyy-MM-dd") == TariheGore)
                    {
                        Filtrelenmis.Add(item);
                    }
                }

            }
            else if (TariheGore == "" && DurumaGore != "0")
            {
                foreach (var item in data)
                {
                    if (item.OrdersStatus == DurumaGore)
                    {
                        Filtrelenmis.Add(item);
                    }
                }
            }
            else if (TariheGore != "" && DurumaGore == "0")
            {
                foreach (var item in data)
                {
                    if (item.PaymentDate.ToString("yyyy-MM-dd") == TariheGore)
                    {
                        Filtrelenmis.Add(item);
                    }
                }
            }


            return View(Filtrelenmis);
        }


        [Route("/Siparisler/Detay/{Id}")]
        public IActionResult Detay(int Id)
        {
            ViewBag.Details = works.OrderDetailsService.GetAll().Where(x => x.OrdersId == Id);
            ViewBag.Address = works.OrderAddressService.GetAll().Where(x => x.OrdersId == Id);

            return View(works.OrdersService.GetById(x=> x.Id == Id));
        }
    }
}
