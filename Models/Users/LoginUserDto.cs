using System.ComponentModel.DataAnnotations;

namespace TravelGreen.Models.Users
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Your password must be {2} to {1} characters long", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
