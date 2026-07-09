using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoMeal.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePizzaPackageTypeOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Am comentat codul pentru a evita "Violation of PRIMARY KEY"
            // deoarece datele există deja în baza de date.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Am comentat codul pentru a evita erori la rollback.
        }
    }
}