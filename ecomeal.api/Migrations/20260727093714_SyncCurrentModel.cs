using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMeal.Api.Migrations
{
    /// <inheritdoc />
    public partial class SyncCurrentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackageImageUrl",
                table: "Package",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "StockReserved",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BusinessImageUrl",
                table: "Business",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Business",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Business",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteBusiness",
                columns: table => new
                {
                    FavoriteBusinessesId = table.Column<int>(type: "int", nullable: false),
                    FavoritedByUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBusiness", x => new { x.FavoriteBusinessesId, x.FavoritedByUsersId });
                    table.ForeignKey(
                        name: "FK_FavoriteBusiness_AspNetUsers_FavoritedByUsersId",
                        column: x => x.FavoritedByUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteBusiness_Business_FavoriteBusinessesId",
                        column: x => x.FavoriteBusinessesId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBusiness_FavoritedByUsersId",
                table: "FavoriteBusiness",
                column: "FavoritedByUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_OrderId",
                table: "Review",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteBusiness");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "PackageImageUrl",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StockReserved",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BusinessImageUrl",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Business");
        }
    }
}
