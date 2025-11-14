using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string urunAd { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string urunBilgi { get; set; }
    }
}
