using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class User
    {
        public int Id { get; set; }
      
        public string? Name { get; set; }

       
        public string? Email { get; set; }
        
        public string? Password { get; set; }

        public string Role { get; set; } // Added role column
    }
}
