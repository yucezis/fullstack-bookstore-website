using Microsoft.AspNetCore.Mvc;
using EticaretWebSitesi.Models.Siniflar;


namespace EticaretWebSitesi.Controllers
{
    public class UrunDetayController : Controller
    {
        private Context _c;

        public UrunDetayController(Context context)
        {
            _c = context;
        }

        public IActionResult Index(int id)
        {
            var urun = _c.uruns.FirstOrDefault(x => x.UrunId == id);
            
            return View(urun);
            
        }

    }
}
