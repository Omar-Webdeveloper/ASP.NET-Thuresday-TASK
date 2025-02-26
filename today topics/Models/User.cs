using System.ComponentModel.DataAnnotations;
namespace today_topics.Models
{
    public partial class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string? Password { get; set; }

        public string Role { get; set; } // Added role column
    }
}
