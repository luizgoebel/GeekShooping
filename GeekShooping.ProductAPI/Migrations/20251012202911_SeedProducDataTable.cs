using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShooping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 4L, "Roupas", "Camiseta do GeekShooping", "https://static.geekshooping.com/img/camiseta-geek.png", "Camiseta Geek", 29.90m },
                    { 5L, "Acessórios", "Caneca personalizada do GeekShooping", "https://static.geekshooping.com/img/caneca-geek.png", "Caneca Geek", 15.50m },
                    { 6L, "Eletrônicos", "Mouse gamer do GeekShooping", "https://static.geekshooping.com/img/mouse-gamer.png", "Mouse Gamer", 199.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);
        }
    }
}
