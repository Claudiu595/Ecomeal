using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoMeal.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameAddressColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_BusinessType_BusinessTypeID",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Package_PackageID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_Business_BusinessID",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_PackageType_PackageTypeID",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PackageType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PackageTypeID",
                table: "Package",
                newName: "PackageTypeId");

            migrationBuilder.RenameColumn(
                name: "BusinessID",
                table: "Package",
                newName: "BusinessId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Package",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StartPickUp",
                table: "Package",
                newName: "PickUpStart");

            migrationBuilder.RenameColumn(
                name: "NoPackage",
                table: "Package",
                newName: "NoPackages");

            migrationBuilder.RenameColumn(
                name: "EndPickUp",
                table: "Package",
                newName: "PickUpEnd");

            migrationBuilder.RenameIndex(
                name: "IX_Package_PackageTypeID",
                table: "Package",
                newName: "IX_Package_PackageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_BusinessID",
                table: "Package",
                newName: "IX_Package_BusinessId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PackageID",
                table: "Order",
                newName: "PackageId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserID",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PackageID",
                table: "Order",
                newName: "IX_Order_PackageId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BusinessType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeID",
                table: "Business",
                newName: "BusinessTypeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Business",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Business",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Business_BusinessTypeID",
                table: "Business",
                newName: "IX_Business_BusinessTypeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Package",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_BusinessType_BusinessTypeId",
                table: "Business",
                column: "BusinessTypeId",
                principalTable: "BusinessType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "Order",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Business_BusinessId",
                table: "Package",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_PackageType_PackageTypeId",
                table: "Package",
                column: "PackageTypeId",
                principalTable: "PackageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Business_BusinessType_BusinessTypeId",
                table: "Business");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Package_PackageId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_Business_BusinessId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_PackageType_PackageTypeId",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PackageType",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PackageTypeId",
                table: "Package",
                newName: "PackageTypeID");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Package",
                newName: "BusinessID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Package",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PickUpStart",
                table: "Package",
                newName: "StartPickUp");

            migrationBuilder.RenameColumn(
                name: "PickUpEnd",
                table: "Package",
                newName: "EndPickUp");

            migrationBuilder.RenameColumn(
                name: "NoPackages",
                table: "Package",
                newName: "NoPackage");

            migrationBuilder.RenameIndex(
                name: "IX_Package_PackageTypeId",
                table: "Package",
                newName: "IX_Package_PackageTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Package_BusinessId",
                table: "Package",
                newName: "IX_Package_BusinessID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "Order",
                newName: "PackageID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PackageId",
                table: "Order",
                newName: "IX_Order_PackageID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BusinessType",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "Business",
                newName: "BusinessTypeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Business",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Business",
                newName: "Adress");

            migrationBuilder.RenameIndex(
                name: "IX_Business_BusinessTypeId",
                table: "Business",
                newName: "IX_Business_BusinessTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Package",
                type: "int",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Business_BusinessType_BusinessTypeID",
                table: "Business",
                column: "BusinessTypeID",
                principalTable: "BusinessType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Package_PackageID",
                table: "Order",
                column: "PackageID",
                principalTable: "Package",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Business_BusinessID",
                table: "Package",
                column: "BusinessID",
                principalTable: "Business",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_PackageType_PackageTypeID",
                table: "Package",
                column: "PackageTypeID",
                principalTable: "PackageType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
