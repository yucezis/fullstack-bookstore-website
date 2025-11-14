using Microsoft.AspNetCore.Mvc;
using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Controllers
{
    public class KategoriController : Controller
    {
        private readonly Context _c;

        public KategoriController(Context context)
        {
            _c = context;
        }
        public IActionResult Index()
        {
            var degerler = _c.kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            _c.kategoris.Add(k);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = _c.kategoris.Find(id);
            _c.kategoris.Remove(ktg);
            _c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = _c.kategoris.Find(k.KategoriID);
            if (kategori == null)
                return NotFound();

            kategori.KategoriAdi = k.KategoriAdi;
            _c.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
