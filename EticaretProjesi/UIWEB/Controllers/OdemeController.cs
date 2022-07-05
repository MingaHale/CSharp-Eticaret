using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Mvc;
using UIWEB.Models;

namespace UIWEB.Controllers
{
    public class OdemeController : Controller
    {
        private readonly IUnitOfWorks works;

        public OdemeController(IUnitOfWorks works)
        {
            this.works = works;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["SepetId"] != null)
            {
                int SepetId = int.Parse(Request.Cookies["SepetId"]);
                var bulunan = works.TemporaryService.GetAll().Where(x => x.BasketCookies == SepetId);

                if (bulunan.Count() == 0)
                {
                    return Redirect("/");
                }
                else
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        int Coockies = int.Parse(Request.Cookies["SepetId"].ToString());
                        return View(works.TemporaryService.GetAll().Where(x => x.BasketCookies == Coockies));
                    }
                    else
                    {
                        return Redirect("/Musteri");

                    }
                }   
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(TeslimatModel teslimat, FaturaModel fatura, string PaymentType)
        {
            int SepetId = int.Parse(Request.Cookies["SepetId"]);

            OrderAddress faturaAdresi = new OrderAddress();
            faturaAdresi.AddressType = false;
            faturaAdresi.FullAddress = fatura.FAdres;
            faturaAdresi.City = fatura.FSehir;
            faturaAdresi.Distrinct = fatura.FIlce;
            faturaAdresi.Phone = fatura.FTelefon;
            faturaAdresi.OrdersId = SepetId;


            OrderAddress teslimatAdresi = new OrderAddress();
            teslimatAdresi.AddressType = true;
            teslimatAdresi.FullAddress = teslimat.TAdres;
            teslimatAdresi.City = teslimat.TSehir;
            teslimatAdresi.Distrinct = teslimat.TIlce;
            teslimatAdresi.Phone = teslimat.TTelefon;
            teslimatAdresi.OrdersId = SepetId;

            //Satın alınan ürünler

            decimal ToplamFiyat = 0;
            decimal IndirimToplam = 0;
            List<OrderDetails> siparisler = new List<OrderDetails>();           
            foreach (var item in works.TemporaryService.GetAll().Where(x=> x.BasketCookies == SepetId))
            {
                OrderDetails o = new OrderDetails();
                o.ProductsId = item.ProductsId;
                o.Price = item.Price;
                o.Images = item.Images;
                o.Piece = item.Piece;
                o.Name = item.Name;
                o.Discount = item.Discount;
                o.OrdersId = item.BasketCookies;
                siparisler.Add(o);

                ToplamFiyat += item.Piece * item.Price;
                IndirimToplam += item.Piece * item.Discount;


            }

            //Sipariş Toplam Bilgileri
            Orders orders = new Orders();
            orders.OrdersStatus = (PaymentType == "Kapıda Ödeme") ? "Onay Bekleniyor" : "Ödeme Bekleniyor";
            orders.TotalDiscount = IndirimToplam;
            orders.PaymentType = PaymentType;
            orders.CustomersId = int.Parse(User.FindFirst(x => x.Type == "Id").Value.ToString());
            orders.TotalPrice = ToplamFiyat;
            orders.Id = SepetId;
            orders.PaymentDate = DateTime.Now;

            //Toplanan bilgiler veri tabanına gönderilir.Önce ana tablo sonra yardımcılar.
            works.OrdersService.Insert(orders);//1. TABLO
            works.OrderAddressService.Insert(faturaAdresi);
            works.OrderAddressService.Insert(teslimatAdresi);
            foreach (var item in siparisler)
            {
                works.OrderDetailsService.Insert(item);
            }

            works.OrdersService.SaveChanges();

            if (works.OrdersService.SaveChanges() == 0)
            {
                return Redirect("/Odeme/Basarisiz");
            }
            else
            {
                return Redirect("/Odeme/Basarili");
            }
            

        }

        //Eğer işlem başarılıysa ve başarılı sayfasına yönlendirildiyse kullanıcı başarılı actionResult tarafından SepetId silmemiz gerekmektedir ki aynı kullanıcı yeni sipariş verdiğinde yeni fatura numarsını ve sepet numarsı oluşsun.
        

        public IActionResult Basarili()
        {
            int SepetNo = int.Parse(Request.Cookies["SepetId"]);
            ViewBag.SiparisNo = SepetNo;

            //Sepet no tarayıcıdan siliyoruz
            var GelenSepetNo = Request.Cookies["SepetId"];
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(-7);
            Response.Cookies.Append("SepetId", GelenSepetNo,cookie);

            return View();
        }
        public IActionResult Basarisiz()
        {
            return View();
        }
    }
}
