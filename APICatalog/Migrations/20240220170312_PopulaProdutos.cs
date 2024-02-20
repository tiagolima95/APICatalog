using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into dbo.Products(Name,Description,Price,ImageUrl,Stock,registrationDate,CategoryId)" +
            "Values('Galaxy S24 Ultra','Galaxy S24 Ultra 256GB',1000.00,'galaxy.jpg',20,GETDATE(),1)");

            migrationBuilder.Sql("Insert into dbo.Products(Name,Description,Price,ImageUrl,Stock,registrationDate,CategoryId)" +
                "Values('Macbook Pro','MacBook Pro 14 256Gb',2000.00,'macbook.jpg',5,GETDATE(),2)");

            migrationBuilder.Sql("Insert into dbo.Products(Name,Description,Price,ImageUrl,Stock,registrationDate,CategoryId)" +
               "Values('Playstation 5','Playstation 5 Slim 1TB',450.00,'playstation.jpg',10,GETDATE(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
