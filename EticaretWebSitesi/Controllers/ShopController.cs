using EticaretWebSitesi.Models.Siniflar;
using EticaretWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Controllers
{
    public class ShopController : Controller
    {
        private Context _c;

        public ShopController(Context context)
        {
            _c = context;
        }

        public IActionResult Index(int id)
        {
            var kategori = _c.kategoris.FirstOrDefault(k => k.KategoriID == id);
            if (kategori == null)
                return NotFound();

            var urunler = _c.uruns
                .Where(u => u.KategoriID == id)
                .ToList();

            foreach (var uruns in urunler)
            {
                if (uruns.UrunGorsel == null)
                {
                    Console.WriteLine($"Hatalı görsel: UrunID: {uruns.UrunId}, Ad: {uruns.UrunAdi}");
                }
            }


            ViewBag.KategoriAdi = kategori.KategoriAdi; 

            return View(urunler);
        }

        public IActionResult MainMenu()
        {
            if (_c == null || _c.uruns == null)
            {
                return NotFound("Veritabanı bağlantısı veya ürün listesi bulunamadı.");
            }

            // IndirimliFiyat null olmayan ve Durum değeri true olan ürünleri al
            var indirimliKitaplar = _c.uruns
                .Where(x => x.IndirimliFiyat.HasValue && x.Durum == true)
                .ToList();

            return View(indirimliKitaplar);

        }

      
           public IActionResult CokSatanKitaplar()
            {
            
            var cokSatanUrunIds = _c.satisHarekets
                .GroupBy(s => s.UrunId)
                .Where(g => g.Count() > 0)
                .Select(g => g.Key)
                .ToList();

            
            var urunler = _c.uruns
                .Where(u => cokSatanUrunIds.Contains(u.UrunId) && u.Durum == true)
                .Include(u => u.Kategori)
                .ToList();

            return View(urunler);
        
           }

        
        public IActionResult hakkimizda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FavoriEkleCikar(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("MusteriMail")))
            {
                TempData["GirisUyarisi"] = "Lütfen giriş yapınız.";
                return Redirect(Request.Headers["Referer"].ToString());
            }


            List<int> favoriler = HttpContext.Session.GetObjectFromJson<List<int>>("favoriler") ?? new List<int>();

            if (favoriler.Contains(id))
            {
                favoriler.Remove(id);
            }
            else
            {
                favoriler.Add(id);
            }

            HttpContext.Session.SetObjectAsJson("favoriler", favoriler);

            
            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer); 
        }

        public IActionResult Favorilerim()
        {
            
            List<int> favoriIdler = HttpContext.Session.GetObjectFromJson<List<int>>("favoriler") ?? new List<int>();

            
            if (!favoriIdler.Any())
            {
                return View(new List<Urun>());
            }

            var favoriUrunler = _c.uruns
                .Where(u => favoriIdler.Contains(u.UrunId))
                .ToList();

            return View(favoriUrunler);
        }
    }
}
