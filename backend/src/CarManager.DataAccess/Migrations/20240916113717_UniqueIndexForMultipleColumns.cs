using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManager.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UniqueIndexForMultipleColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId_ModelName_BodyTypeId_SeatsCount",
                table: "Cars",
                columns: new[] { "BrandId", "ModelName", "BodyTypeId", "SeatsCount" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandId_ModelName_BodyTypeId_SeatsCount",
                table: "Cars");
        }
    }
}
