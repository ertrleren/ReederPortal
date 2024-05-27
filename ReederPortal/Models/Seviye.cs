using System.ComponentModel.DataAnnotations;

namespace ReederPortal.Models
{
    public class Seviye
    {
        [Key]
        public int SeviyeID { get; set; }
        public string SeviyeAd { get; set; }


        // Personel ile ilişki
        public IList<Personel> Personels { get; set; }
    }
}
