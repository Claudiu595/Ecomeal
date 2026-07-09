using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecomeal.api.Migrations
{
    /// <inheritdoc />
    public partial class SeedBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.InsertData(
        table: "Business",
        columns: new[] { "Name", "Adress", "Description", "Contact", "BusinessTypeID" },
        values: new object[,]
        {
            { "Pizza Imiza", "Craiova", "Probabil cea mai buna", "pizza@imiza.ro", 1 },
            { "KEC", "Craiova", "It's Toe Liking Good", "kec@good.ro", 3 },
            { "Shaorma Prietenii", "Craiova", "Nu-ti mai trebuie dusmani", "sh@orma.ro", 3 },
            { "MonDay", "Craiova", "House of burgers", "first@weekday.ro", 3 },
            { "Peter", "Craiova", "Traditie din 2025", "craiova@peter.com", 2 },
            { "The House", "Craiova", "Pizza pe cuptor de lemne", "pizza@house.ro", 1 },
            { "Burger Queen", "Bucuresti", "Her Majesty's secret burger", "burger@queen.ro", 3 },
            { "Luka", "Bucuresti", "Kovrigaria poporului", "luka@covrigi.ro", 2 },
            { "Pizza Hot", "Bucuresti", "Your pizza, you way.", "pizza@hooot.ro", 1 },
            { "Peter", "Bucuresti", "Traditie din 2025", "bucuresti@peter.com", 2 }
        });
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    // Aici poți adăuga ștergerea lor în caz de rollback
    migrationBuilder.Sql("DELETE FROM [Business] WHERE [Name] IN ('Pizza Imiza', 'KEC', ...)");
}
    }
}
