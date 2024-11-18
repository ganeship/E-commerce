
using E_commerce.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data.Context
{
    public class DBcontext:DbContext
    {
        public DBcontext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<user> Users { get; set; }

        public DbSet<seller> Sellers { get; set; }

        public DbSet<product> Products { get; set; }

        public DbSet<order> Orders { get; set; }

        public DbSet<payment> Payments { get; set; }

        public DbSet<cart> Carts { get; set; }
        
        public DbSet<review>Reviews { get; set; }
        

    }
}
