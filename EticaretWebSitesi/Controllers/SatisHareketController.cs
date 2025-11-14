using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Controllers
{
    public class SatisHareketController : Controller
    {
        private readonly Context _c;

        public SatisHareketController(Context context)
        {
            _c = context;
        }

        public IActionResult Index()
        {
            var degerler = _c.satisHarekets.Include(x => x.Urun).Include(x => x.Musteri).ToList();

            return View(degerler);
        }


        public IActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in _c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdi,
                                               Value = x.UrunId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in _c.musteris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.MusteriAdi + " " + x.MusteriSoyadi,
                                               Value = x.MusteriId.ToString()
                                           }).ToList();

            ViewBag.deger1 = deger1;
            ViewBag.deger2 = deger2;
            var deger = _c.satisHarekets.Find(id);
            return View("SatisGetir", deger);
        }

        public IActionResult SatisGuncelle(SatisHareket s)
        {
            var deger = _c.satisHarekets.Find(s.SatisHareketId);
            deger.MusteriId = s.MusteriId;
            deger.UrunId = s.UrunId;
            deger.Fiyat = s.Fiyat;
            deger.Adet = s.Adet;
            deger.ToplamTutar = s.ToplamTutar;
            deger.Tarih = s.Tarih;
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SatisDetay(int id) 
        {
            var deger = _c.satisHarekets
                        .Include(x => x.Musteri)
                        .Include(x => x.Urun)
                        .Where(x => x.SatisHareketId == id)
                        .ToList();
            return View(deger);

        }
    }
}












