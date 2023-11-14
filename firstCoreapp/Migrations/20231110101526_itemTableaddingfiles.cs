using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstCoreapp.Migrations
{
    /// <inheritdoc />
    public partial class itemTableaddingfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagepath",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagepath",
                table: "items");
        }
    }
}
