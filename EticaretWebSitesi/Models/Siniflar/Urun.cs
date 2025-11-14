using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string UrunAdi { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string UrunMarka { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string? UrunYazar { get; set; }

        public short UrunStok { get; set; }

        public decimal UrunSatisFiyati { get; set; }
        public bool UrunStokDurum { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }
        public bool Durum { get; set; }

        public decimal? IndirimliFiyat { get; set; }


        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Aciklama { get; set; }


        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}

