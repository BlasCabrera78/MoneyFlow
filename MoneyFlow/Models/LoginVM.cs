using System.ComponentModel.DataAnnotations;

namespace MoneyFlow.Models
{
    public class LoginVM
    {
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
