using System.ComponentModel.DataAnnotations;

namespace ReederPortal.Models
{
    public class Unvan
    {
        [Key]
        public int UnvanID { get; set; }
        public string UnvanAd { get; set; }
   

        // Personel ile ilişki
        public IList<Personel> Personels { get; set; }
    }
}
