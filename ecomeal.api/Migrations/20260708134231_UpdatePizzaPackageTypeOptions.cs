using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecomeal.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePizzaPackageTypeOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PackageType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza margherita" },
                    { 2, "Pizza pepperoni" },
                    { 3, "Pizza veggie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackageType",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
