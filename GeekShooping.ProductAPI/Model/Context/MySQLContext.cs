using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Model.Context;

public class MySQLContext : DbContext
{
    public MySQLContext() { }
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 4,
                Name = "Camiseta Geek",
                Price = 29.90M,
                Description = "Camiseta do GeekShooping",
                CategoryName = "Roupas",
                ImageUrl = "https://static.geekshooping.com/img/camiseta-geek.png"
            },
            new Product
            {
                Id = 5,
                Name = "Caneca Geek",
                Price = 15.50M,
                Description = "Caneca personalizada do GeekShooping",
                CategoryName = "Acessórios",
                ImageUrl = "https://static.geekshooping.com/img/caneca-geek.png"
            },
            new Product
            {
                Id = 6,
                Name = "Mouse Gamer",
                Price = 199.90M,
                Description = "Mouse gamer do GeekShooping",
                CategoryName = "Eletrônicos",
                ImageUrl = "https://static.geekshooping.com/img/mouse-gamer.png"
            }
        );
    }
}
