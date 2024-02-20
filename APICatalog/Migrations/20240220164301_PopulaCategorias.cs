using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into dbo.Categories(Name, ImageUrl) Values('SmartPhones','smartphone.jpg')");
            migrationBuilder.Sql("Insert into dbo.Categories(Name, ImageUrl) Values('Computers','computer.jpg')");
            migrationBuilder.Sql("Insert into dbo.Categories(Name, ImageUrl) Values('Videogames','videogame.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
