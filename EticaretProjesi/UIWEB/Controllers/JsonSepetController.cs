using Bussiness.UnitOfWork;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.Controllers
{
    public class JsonSepetController : Controller
    {
        private readonly IUnitOfWorks works;
        public JsonSepetController(IUnitOfWorks works)
        {
            this.works = works;
        }

        public JsonResult Insert(int AlinanId)
        {
            //Kullanıcının tarayıcısında çerezler bölümünde, bizim proje tarafınfan   SepetId isimli çerez varmı?
            if (Request.Cookies["SepetId"] == null) ///Sepet var mı yok mu?
            {
                Random random = new Random();
                int OlusturulanSepetId = 0;
                do
                {
                    OlusturulanSepetId = random.Next(0, 9999999);
                    //TemporaryBasket tablosuna git BasketCookies sütununda ara varsa tekrar oluşturacak.
                } while (works.TemporaryService.GetById(x=> x.BasketCookies == OlusturulanSepetId) != null);

                CookieOptions cookieOptions = new CookieOptions(); //Kullanıcını tarayıcısında saklamamızı sağlayan çerez yapısı
                cookieOptions.Expires = DateTime.Now.AddDays(7); //Kaç gün saklayacağımızı belirtiyor.
                //SepetId isimşi çerez kullanıcı tarayıcısınfa belirlenen ayarlara göre oluşturuluyor.
                Response.Cookies.Append("SepetId", OlusturulanSepetId.ToString(), cookieOptions);

                //Artık sepet oluşturma işlemi bittiği için kullanıcının seçmiş ürünü sepetine ekliyoruz
                var BulunanUrun = works.ProductsService.GetById(x => x.Id == AlinanId);
                TemporaryBaskets Sepet = new TemporaryBaskets();
                Sepet.Price = BulunanUrun.Price;
                Sepet.BasketCookies = OlusturulanSepetId;
                Sepet.ProductsId = BulunanUrun.Id;
                Sepet.Name = BulunanUrun.Name;
                Sepet.Piece = 1;
                Sepet.Discount = BulunanUrun.Discount;
                Sepet.Images = BulunanUrun.ImagesName;
                works.TemporaryService.Insert(Sepet);
                works.TemporaryService.SaveChanges();
            }
            else
            {
                int KullanicininSepeti = int.Parse(Request.Cookies["SepetId"].ToString());
                var BulunanUrun = works.ProductsService.GetById(x=> x.Id == AlinanId);//Ürün Bulundu
                //ÜrünId ile SepetId Veritabanına gönderiliyor, eğer bu bilgilere ait satır var ise bana geliyor
                var SepetKontrol = works.TemporaryService.GetById(x=> x.BasketCookies == KullanicininSepeti && x.ProductsId == BulunanUrun.Id);
                if (SepetKontrol != null) //var ise, Satır gelmiş ise.
                {
                    SepetKontrol.Piece++;
                    works.TemporaryService.Update(SepetKontrol);
                    works.TemporaryService.SaveChanges();
                }
                else
                {
                    TemporaryBaskets Sepet = new TemporaryBaskets();
                    Sepet.Price = BulunanUrun.Price;
                    Sepet.BasketCookies = KullanicininSepeti;
                    Sepet.ProductsId = BulunanUrun.Id;
                    Sepet.Name = BulunanUrun.Name;
                    Sepet.Piece = 1;
                    Sepet.Discount = BulunanUrun.Discount;
                    Sepet.Images = BulunanUrun.ImagesName;
                    works.TemporaryService.Insert(Sepet);
                    works.TemporaryService.SaveChanges();
                }
            }
            return Json("");
        }

        public JsonResult Delete(int AlinanId)
        {
            works.TemporaryService.Delete(x => x.Id == AlinanId);
            works.TemporaryService.SaveChanges();
            return Json("");
        }

        public JsonResult AdetIslem(int AlinanId, int islem)
        {
            //Ürünün adeti azaltılacak mı? Arttırılacak mı?
            //Adet azaltılacak ise, alınacak adet sayısı 1'den küçük olmayacak
            //Adet arttırılacak ise, stoktaki adetten fazla ürün alınmayacak

            var bulunan = works.TemporaryService.GetById(x => x.Id == AlinanId);

            if (islem == 0)
            {
                if (bulunan.Piece > 1)
                {
                    bulunan.Piece--;
                    works.TemporaryService.Update(bulunan);
                    works.TemporaryService.SaveChanges();
                    return Json("Adet Azaltılmıştır");
                }
                else
                {
                    return Json("Minimum 1 Adet Alınabilir");
                }
            }
            else
            {
                var urun = works.ProductsService.GetById(x=> x.Id == bulunan.ProductsId);
                if (bulunan.Piece < urun.Stock)
                {
                    bulunan.Piece++;
                    works.TemporaryService.Update(bulunan);
                    works.TemporaryService.SaveChanges();
                    return Json("Adet Arttırılmıştır");
                }
                else
                {
                    return Json("Maximum" +urun.Stock+"Adet Sipariş Verebilirsiniz");
                }
            }
        }
    }
}
