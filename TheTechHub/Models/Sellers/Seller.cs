using System.ComponentModel.DataAnnotations;

namespace TechHub.Models.Seller
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public string Password { get; set; } = "";
    }
}
