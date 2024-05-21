using Microsoft.EntityFrameworkCore;
using WebFood_2.Models;

namespace WebFood_2.Data;

public class WebFoodContext:DbContext
{
    public WebFoodContext(DbContextOptions<WebFoodContext> options):base(options)
    {
        
    }

        
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //modelBuilder.Entity<OrderDetail>()
        //.HasOne(od => od.Order)
        //.WithMany(o => o.OrderDetails)
        //.HasForeignKey(od => od.OrderId)
        //.OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<OrderDetail>()
        //.HasOne(od => od.Product)
        //.WithOne(o => o.OrderDetails)
        //.HasForeignKey(od => od.OrderId)
        //.OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
    
}