using System.ComponentModel.DataAnnotations;

namespace LoveFirst.Models.ViewModel
{
    public class ProfileViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
