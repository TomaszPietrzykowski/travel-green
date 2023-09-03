using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelGreen.Migrations
{
    /// <inheritdoc />
    public partial class SeededCountriesAndhodtels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Hotels",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[,]
                {
                    { 1, "JAM", "Jamaica" },
                    { 2, "BS", "Bahamas" },
                    { 3, "CI", "Cayman Islands" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "Negril", 1, "Sandals R&S", 4.5 },
                    { 2, "George Town", 3, "Comfort Suites", 4.2999999999999998 },
                    { 3, "Nassua", 2, "Grand De Moin", 4.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Hotels",
                newName: "Adress");
        }
    }
}
