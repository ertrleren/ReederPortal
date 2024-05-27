using System.ComponentModel.DataAnnotations;

namespace ReederPortal.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
