using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}