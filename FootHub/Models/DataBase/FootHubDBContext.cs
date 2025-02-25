using Microsoft.EntityFrameworkCore;
using FootHub.Models.Entitites;
namespace FootHub.Models.DataBase;
public class FootHubDBContext : DbContext
{
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    public FootHubDBContext(DbContextOptions<FootHubDBContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.UserId, sc.ShoeId });
        modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.User)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.Cascade);  

        modelBuilder.Entity<ShoppingCart>()
                    .HasOne(sc => sc.Shoe)
                    .WithMany(s => s.ShoppingCarts)
                    .HasForeignKey(sc => sc.ShoeId)
                    .OnDelete(DeleteBehavior.Cascade);
    }

}
    

