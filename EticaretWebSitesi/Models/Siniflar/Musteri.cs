using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EticaretWebSitesi.Models.Siniflar
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string MusteriAdi { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string MusteriSoyadi { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string MusteriSehir { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string MusteriTelNo { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız!")]
        public string MusteriMail { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string MusteriSifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}