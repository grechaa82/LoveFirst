using System.ComponentModel.DataAnnotations;

namespace LoveFirst.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
