using EticaretWebSitesi.Models.Siniflar;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Favori
    {
        public int FavoriId { get; set; }

        public int MusteriId { get; set; }  

        public int UrunId { get; set; }
        public Urun Urun { get; set; }

    }
}
