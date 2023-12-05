using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThump.Migrations
{
    /// <inheritdoc />
    public partial class Change_instrcution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 1,
                column: "instructions",
                value: "Allow soil to dry between waterings.");

            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "plant_id" },
                values: new object[] { "Avoid overwatering.", 1 });

            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "plant_id" },
                values: new object[] { "Keep soil consistently moist but not soggy.", 2 });

            migrationBuilder.InsertData(
                table: "instructions",
                columns: new[] { "id", "instructions", "plant_id" },
                values: new object[,]
                {
                    { 4, "Water when the top inch of soil feels dry.", 2 },
                    { 5, " Allow the soil to dry out between waterings.", 3 },
                    { 6, "Water sparingly.", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 1,
                column: "instructions",
                value: "Allow soil to dry between waterings, avoid overwatering.");

            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "instructions", "plant_id" },
                values: new object[] { "Keep soil consistently moist but not soggy; water when the top inch of soil feels dry.", 2 });

            migrationBuilder.UpdateData(
                table: "instructions",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "instructions", "plant_id" },
                values: new object[] { " Allow the soil to dry out between waterings; water sparingly.", 3 });
        }
    }
}
