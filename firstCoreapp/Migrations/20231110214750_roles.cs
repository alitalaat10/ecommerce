using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace firstCoreapp.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e659bde-2012-4973-95a3-d40e1d6f364a", "eb4638f3-04b9-482f-b647-fddf3d9295b0", "Admin", "ADMIN" },
                    { "a6a48161-b086-4b50-9897-b3c337893f7a", "759d1ca8-380e-480e-9df5-f0a9ae1db66c", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e659bde-2012-4973-95a3-d40e1d6f364a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6a48161-b086-4b50-9897-b3c337893f7a");
        }
    }
}
