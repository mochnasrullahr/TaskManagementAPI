using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
