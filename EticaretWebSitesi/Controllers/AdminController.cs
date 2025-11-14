using EticaretWebSitesi.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var degerler = _c.admins.ToList();
            return View(degerler);
            
        }

        private readonly Context _c;

        public AdminController(Context context)
        {
            _c = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string sifre)
        {
            var admin = _c.admins.FirstOrDefault(x => x.KullaniciAdi == email && x.Sifre == sifre);

            if (admin != null)
            {
                HttpContext.Session.SetString("AdminKullanici", email);
                return RedirectToAction("Index", "Istatistik");
            }

            ViewBag.Hata = "Hatalı Şifre veya Mail Adresi";
            return View();
        }

        public IActionResult Panel()
        {
            return View(); // boş admin paneli
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("MainMenu", "Shop");
        }


        [HttpPost]
        public IActionResult AdminEkleme(Models.Siniflar.Admin a)
        {
            
            _c.admins.Add(a);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AdminSil(int id)
        {
            var admin = _c.admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            _c.admins.Remove(admin);
            _c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdminGuncelle(Admin a)
        {
            var admin = _c.admins.Find(a.AdminId);
            if (admin != null)
            {
                admin.KullaniciAdi = a.KullaniciAdi;
                admin.Sifre = a.Sifre;
                admin.Yetki = a.Yetki;
                _c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
