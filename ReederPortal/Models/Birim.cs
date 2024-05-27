using System.ComponentModel.DataAnnotations;

namespace ReederPortal.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }
        public string BirimAd { get; set; }

        // Personel ile ilişki
        public IList<Personel> Personels { get; set; }
    }
}
