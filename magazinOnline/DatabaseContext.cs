using Microsoft.EntityFrameworkCore;
using magazinOnline.Entities;
using magazinOnline.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace magazinOnline;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {



    }

    public DatabaseContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=magazinOnline;Username=postgres;Password=project");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<CustomerCart> CustomerCarts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
}