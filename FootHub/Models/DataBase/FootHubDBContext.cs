using Microsoft.EntityFrameworkCore;
using FootHub.Models.Entitites;
namespace FootHub.Models.DataBase;
public class FootHubDBContext : DbContext
{
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<User> Users { get; set; }


    public FootHubDBContext(DbContextOptions<FootHubDBContext> options)
        : base(options)
    {

    }
    

}