using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelGreen.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4498e730-f677-4502-b329-ef6b0c7c9eff", "6482c893-0ce3-4d22-9eeb-281f6de6e6c3", "Administrator", "ADMINISTRATOR" },
                    { "8e8cfe86-eb29-4bec-a9f4-b7f5f4928462", "8070f217-ad51-4316-bbfd-e30fa37d46ca", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4498e730-f677-4502-b329-ef6b0c7c9eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e8cfe86-eb29-4bec-a9f4-b7f5f4928462");
        }
    }
}
