using Microsoft.EntityFrameworkCore;

namespace TechHub.Models
{
    public class Dbcontext:DbContext
    {
        public Dbcontext(DbContextOptions options)  :base(options){ }

        public DbSet<Products.Product> Product { get; set; }

        public DbSet<Seller.Seller> Sellers { get; set; }

        public DbSet<Users.Users> Users { get; set; }

     


    }


}
