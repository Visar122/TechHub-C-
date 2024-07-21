using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechHub.Models.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(40)")]

        public string ProductName { get; set; } = "";

       

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Category { get; set; } = "";
        public string Color { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";




    }
}
