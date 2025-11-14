using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar;
using Newtonsoft.Json;
using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Controllers
{
    public class SepetController : Controller
    {

        private readonly Context _c;

        public SepetController(Context context)
        {
            _c = context;
        }


        [HttpPost]
        public IActionResult Odeme()
        {
            
            return RedirectToAction("OdemeSayfasi");
        }

        public IActionResult OdemeSayfasi()
        {
            return View("Odeme");
        }
        [HttpPost]
        public IActionResult OdemeTamamla(string number, string name, string expiry, string cvc)
        {
            var sepetListesi = HttpContext.Session.GetString("sepet");
            if (string.IsNullOrEmpty(sepetListesi))
            {
                return RedirectToAction("Index", "Sepet");
            }

            List<OdemeSepeti> sepet = JsonConvert.DeserializeObject<List<OdemeSepeti>>(sepetListesi);

            foreach (var item in sepet)
            {
                var urun = _c.uruns.FirstOrDefault(x => x.UrunId == item.Urun.UrunId); 
                if (urun != null && urun.UrunStok >= item.Adet)
                {
                    urun.UrunStok -= (short)item.Adet;

                    var fiyat = urun.IndirimliFiyat ?? urun.UrunSatisFiyati;
                    int musteriId = Convert.ToInt32(HttpContext.Session.GetString("MusteriId"));

                    var satis = new SatisHareket
                    {
                        UrunId = urun.UrunId,
                        MusteriId = musteriId,
                        Adet = item.Adet,
                        Fiyat = fiyat,
                        ToplamTutar = fiyat * item.Adet,
                        Tarih = DateTime.Now
                    };

                    _c.satisHarekets.Add(satis);
                }
            }

           
                _c.SaveChanges();
            
            HttpContext.Session.Remove("sepet");
            TempData["OdemeBasarili"] = true;
            return RedirectToAction("OdemeBasarili");
        }


        public IActionResult OdemeBasarili()
        {
            return View();
        }

    }
}
