using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar;
using Newtonsoft.Json;
using EticaretWebSitesi.Models;


namespace EticaretWebSitesi.Controllers
{
    public class UrunController : Controller
    {
        private Context _c;

        public UrunController(Context context)
        {
            _c = context;
        }

        public IActionResult Index()
        {
            ViewBag.Kategoriler = _c.kategoris.Select(k => new SelectListItem
            {
                Text = k.KategoriAdi,
                Value = k.KategoriID.ToString()
            }).ToList();

            var urunler = _c.uruns.Where(u => u.Durum == true)
                                  .Include(u => u.Kategori)
                                  .ToList();

            return View(urunler);

        }


        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.Durum = true;
                _c.uruns.Add(urun);
                _c.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategoriler = _c.kategoris.Select(k => new SelectListItem
            {
                Text = k.KategoriAdi,
                Value = k.KategoriID.ToString()
            }).ToList();

            var urunler = _c.uruns.Include(u => u.Kategori).ToList();
            return View("Index", urunler);
        }


        public ActionResult UrunSil(int id)
        {
            var u = _c.uruns.Find(id);
            u.Durum = false;
            _c.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult UrunGetir(int id)
        {

            List<SelectListItem> dgr1 = (from x in _c.kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAdi,
                                             Value = x.KategoriID.ToString(),
                                         }).ToList();

            ViewBag.dgr1 = dgr1;

            var urun = _c.uruns.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = _c.uruns.Find(u.UrunId);
            urun.UrunAdi = u.UrunAdi;
            urun.UrunStok = u.UrunStok;
            urun.UrunSatisFiyati = u.UrunSatisFiyati;
            urun.UrunStokDurum = u.UrunStokDurum;
            urun.IndirimliFiyat = u.IndirimliFiyat;
            urun.Durum = u.Durum;
            urun.UrunYazar = u.UrunYazar;
            urun.UrunMarka = u.UrunMarka;
            urun.UrunGorsel = u.UrunGorsel;
            urun.KategoriID = u.KategoriID;
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListe()
        {
            var deger = _c.uruns.ToList();
            return View(deger);
        }

        private List<OdemeSepeti> GetSepet()
        {
            var sepetJson = HttpContext.Session.GetString("sepet");

            if (string.IsNullOrEmpty(sepetJson))
            {
                var bosSepet = new List<OdemeSepeti>();
                HttpContext.Session.SetString("sepet", JsonConvert.SerializeObject(bosSepet));
                return bosSepet;
            }

            return JsonConvert.DeserializeObject<List<OdemeSepeti>>(sepetJson);
        }


        [HttpPost]
        public ActionResult SepeteEkle(int id, int adet=1)
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MusteriMail")))
            {
                TempData["GirisUyarisi"] = "Lütfen giriş yapınız.";
                return Redirect(Request.Headers["Referer"].ToString());
            }

            var urun = _c.uruns.FirstOrDefault(u => u.UrunId == id);
            if (urun == null)
                return NotFound();

            List<OdemeSepeti> sepet = HttpContext.Session.GetObjectFromJson<List<OdemeSepeti>>("sepet") ?? new List<OdemeSepeti>();

            var mevcut = sepet.FirstOrDefault(x => x.Urun.UrunId == id);
            if (mevcut != null)
            {
                mevcut.Adet += adet;
            }
            else
            {
                sepet.Add(new OdemeSepeti { Urun = urun, Adet = adet });
            }

            HttpContext.Session.SetObjectAsJson("sepet", sepet);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public ActionResult Sepetim()
        {
            var sepet = GetSepet();

            decimal toplamTutar = 0m;

            foreach (var item in sepet)
            {
                decimal fiyat = (item.Urun.IndirimliFiyat.HasValue && item.Urun.IndirimliFiyat.Value > 0)
                                ? item.Urun.IndirimliFiyat.Value
                                : item.Urun.UrunSatisFiyati;

                toplamTutar += fiyat * item.Adet;
            }

            ViewBag.toplamTutar = toplamTutar;

            return View(sepet);
        }

        [HttpPost]
        public IActionResult AdetGuncelle(int id, int adet)
        {
            List<OdemeSepeti> sepet = HttpContext.Session.GetObjectFromJson<List<OdemeSepeti>>("sepet");
            var item = sepet.FirstOrDefault(x => x.Urun.UrunId == id);
            if (item != null)
            {
                item.Adet = adet;
            }
            HttpContext.Session.SetObjectAsJson("sepet", sepet);
            return RedirectToAction("Sepetim", "Urun");

        }

        public IActionResult Sepet()
        {
            List<OdemeSepeti> sepet = HttpContext.Session.GetObjectFromJson<List<OdemeSepeti>>("sepet") ?? new List<OdemeSepeti>();
            decimal toplamTutar = 0m;

            foreach (var item in sepet)
            {
                decimal fiyat = (item.Urun.IndirimliFiyat.HasValue && item.Urun.IndirimliFiyat.Value > 0)
                                ? item.Urun.IndirimliFiyat.Value
                                : item.Urun.UrunSatisFiyati;

                toplamTutar += fiyat * item.Adet;
            }

            ViewBag.toplamTutar = toplamTutar;
            return View(sepet);
        }

        public IActionResult IndirimliUrunler()
        {
            var indirimliKitaplar = _c.uruns
                .Where(x => x.IndirimliFiyat != null && x.IndirimliFiyat < x.UrunSatisFiyati && x.Durum == true)
                .ToList();

            return View(indirimliKitaplar);
        }

        [HttpPost]
        public IActionResult SepettenCikar(int id)
        {
            List<OdemeSepeti> sepet = HttpContext.Session.GetObjectFromJson<List<OdemeSepeti>>("sepet") ?? new List<OdemeSepeti>();

            var silinecek = sepet.FirstOrDefault(x => x.Urun.UrunId == id);
            if (silinecek != null)
            {
                sepet.Remove(silinecek);
                HttpContext.Session.SetObjectAsJson("sepet", sepet);
            }

            return RedirectToAction("Sepetim", "Urun");
        }
    }
}
















