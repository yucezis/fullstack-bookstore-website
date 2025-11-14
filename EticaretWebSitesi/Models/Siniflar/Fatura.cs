using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Fatura
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "CHAR")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public ICollection<FaturaIci> FaturaIcis { get; set; }
    }
}
