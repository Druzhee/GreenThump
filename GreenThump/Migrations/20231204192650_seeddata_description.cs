using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThump.Migrations
{
    /// <inheritdoc />
    public partial class seeddata_description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 1,
                column: "description",
                value: "Sansevieria plants are characterized by their long, upright, and sword-shaped leaves");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 2,
                column: "description",
                value: "commonly known as peace lilies, is a genus of flowering plants in the family Araceae. ");

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "id",
                keyValue: 3,
                column: "description",
                value: "is a popular and hardy indoor plant known for its tolerance of low light conditions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Plants");
        }
    }
}
