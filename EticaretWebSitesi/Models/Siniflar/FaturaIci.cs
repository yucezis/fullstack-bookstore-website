using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class FaturaIci
    {

        [Key]
        public int FaturaIciId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public Fatura fatura { get; set; }
    }
}