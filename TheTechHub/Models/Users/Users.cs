using System.ComponentModel.DataAnnotations;

namespace TechHub.Models.Users
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Password { get; set; } = "";
    }
}



