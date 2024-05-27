using System.ComponentModel.DataAnnotations;

namespace ReederPortal.Models
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public long? TcKimlikNo { get; set; }
        public string? PersonelAd { get; set; }
        public string? PersonelSoyad { get; set; }
        public string? DogumYer { get; set; }
        public DateTime DogumTarih { get; set; }
        public string? Cinsiyet { get; set; }
        public string? SurucuBelgesi { get; set; }
        public string? MedeniDurum { get; set; }
        public string? EsCalismaDurum { get; set; }
        public string? CocukSayisi { get; set; }
        public string? SigaraKullanimi { get; set; }
        public string? Hobi { get; set; }
        public string? Mezuniyet { get; set; }
        public DateTime IseBaslamaTarih { get; set; }
        public string? Fotograf { get; set; }

        // Birim ile ilişki
        public int BirimID { get; set; }
        public Birim Birim { get; set; }

        // Unvan ile ilişki
        public int UnvanID { get; set; }
        public Unvan Unvan { get; set; }

        // Seviye ile ilişki
        public int SeviyeID { get; set; }
        public Seviye Seviye { get; set; }

        // Kullanıcı girişi için ek alanlar
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

       

    }
}
