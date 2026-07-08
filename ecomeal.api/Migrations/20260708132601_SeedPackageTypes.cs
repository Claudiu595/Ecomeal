using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecomeal.api.Migrations
{
    /// <inheritdoc />
    public partial class SeedPackageTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPackage = table.Column<int>(type: "int", nullable: false),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StartPickUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndPickUp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Package_Business_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Business",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_BusinessID",
                table: "Package",
                column: "BusinessID");

            migrationBuilder.InsertData(
                table: "PackageType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Meniu local" },
                    { 2, "Meniu vegetarian" },
                    { 3, "Meniu premium" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackageType",
                keyColumn: "ID",
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DropTable(
                name: "Package");
        }
    }
}
