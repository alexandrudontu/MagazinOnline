using magazinOnline.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace magazinOnline;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=magazinOnline;Username=postgres;Password=project");

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public ApplicationDbContext()
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