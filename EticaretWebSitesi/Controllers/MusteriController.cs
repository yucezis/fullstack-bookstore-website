using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar;


namespace EticaretWebSitesi.Controllers
{
    public class MusteriController : Controller
    {
        private readonly Context _c;

        public MusteriController(Context context)
        {
            _c = context;
        }

        public IActionResult Index()
        {
            var degerler = _c.musteris.Where(x=>x.Durum==true).ToList();
            return View(degerler);
            
        }

        [HttpGet]
        public IActionResult MusteriEkleme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MusteriEkleme(Musteri m)
        {
            m.Durum = true;
            _c.musteris.Add(m);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriSil(int id)
        {
            var u = _c.musteris.Find(id);
            u.Durum = false;
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriGetir(int id)
        {
            var musteri = _c.musteris.Find(id);
            return View("MusteriGetir", musteri);

        }

        public IActionResult MusteriGuncelle(Musteri m)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriGetir");
            }
                

            var mtr = _c.musteris.Find(m.MusteriId);
            mtr.MusteriAdi = m.MusteriAdi;
            mtr.MusteriSoyadi = m.MusteriSoyadi;
            mtr.MusteriSoyadi = m.MusteriSehir;
            mtr.MusteriMail = m.MusteriMail;
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MusteriAlisveris(int id)
        {
            var deger = _c.satisHarekets.Where(x=>x.MusteriId==id).ToList();
            var musteri = _c.musteris.Where(x => x.MusteriId == id).Select(y=>y.MusteriAdi+" "+y.MusteriSoyadi).FirstOrDefault();
            ViewBag.musteri=musteri;
            return View(deger);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string sifre)
        {
            var musteri = _c.musteris.FirstOrDefault(x => x.MusteriMail == email && x.MusteriSifre == sifre && x.Durum == true);

            if (musteri != null)
            {
                HttpContext.Session.SetString("MusteriId", musteri.MusteriId.ToString()); 
                HttpContext.Session.SetString("MusteriMail", musteri.MusteriMail);
                HttpContext.Session.SetString("MusteriAdSoyad", musteri.MusteriAdi + " " + musteri.MusteriSoyadi);

                return RedirectToAction("MainMenu", "Shop");
            }

            ViewBag.Hata = "Hatalı Şifre veya Mail Adresi";
            return View();
        }


        public IActionResult Hesabim()
        {
            var mail = HttpContext.Session.GetString("MusteriMail");

            if (string.IsNullOrEmpty(mail))
            {
                return RedirectToAction("Login", "Musteri");
            }

            var musteri = _c.musteris
                .Include(m => m.SatisHarekets)
                .ThenInclude(s => s.Urun) 
                .FirstOrDefault(m => m.MusteriMail == mail);

            return View(musteri);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("MainMenu", "Shop");
        }

        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Musteri musteri, string MusteriSifreTekrar)
        {
            if (ModelState.IsValid)
            {
                if (musteri.MusteriSifre != MusteriSifreTekrar)
                {
                    ViewBag.SifreHata = "Şifreler uyuşmuyor.";
                    return View();
                }

                var mevcutMusteri = _c.musteris.FirstOrDefault(m => m.MusteriMail == musteri.MusteriMail);
                if (mevcutMusteri != null)
                {
                    ViewBag.Hata = "Bu mail adresiyle kayıtlı bir kullanıcı zaten var.";
                    return View();
                }

                musteri.Durum = true;

                _c.musteris.Add(musteri);
                _c.SaveChanges();

                HttpContext.Session.SetString("MusteriId", musteri.MusteriId.ToString());
                HttpContext.Session.SetString("MusteriAdSoyad", musteri.MusteriAdi + " " + musteri.MusteriSoyadi);

                
                return RedirectToAction("Shop", "MainMenu");
            }

            return View();
        }


        [HttpPost]
        public IActionResult BilgiGuncelle(Musteri musteri)
        {
            var guncellenecekMusteri = _c.musteris.Find(musteri.MusteriId);
            if (guncellenecekMusteri == null)
            {
                return NotFound();
            }

            guncellenecekMusteri.MusteriAdi = musteri.MusteriAdi;
            guncellenecekMusteri.MusteriSoyadi = musteri.MusteriSoyadi;
            guncellenecekMusteri.MusteriSehir = musteri.MusteriSehir;
            guncellenecekMusteri.MusteriTelNo = musteri.MusteriTelNo;
            guncellenecekMusteri.MusteriMail = musteri.MusteriMail;

            _c.SaveChanges();

            return RedirectToAction("Hesabim");
        }

        public IActionResult HesapSil(int id)
        {
            var h = _c.musteris.Find(id);
            h.Durum = false;
            _c.SaveChanges();
            return RedirectToAction("MainMenu", "Shop");

        }
    }
}
