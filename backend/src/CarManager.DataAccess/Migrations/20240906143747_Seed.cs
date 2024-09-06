using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Audi" },
                    { Guid.NewGuid(), "Ford" },
                    { Guid.NewGuid(), "Jeep" },
                    { Guid.NewGuid(), "Nissan" },
                    { Guid.NewGuid(), "Toyota" }
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Седан" },
                    { Guid.NewGuid(), "Хэтчбек" },
                    { Guid.NewGuid(), "Универсал" },
                    { Guid.NewGuid(), "Минивэн" },
                    { Guid.NewGuid(), "Внедорожник" },
                    { Guid.NewGuid(), "Купе" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM BodyTypes", true);
            migrationBuilder.Sql("DELETE FROM Brands", true);
        }
    }
}
