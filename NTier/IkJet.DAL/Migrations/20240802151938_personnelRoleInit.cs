using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkJet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class personnelRoleInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, null, "Personnel", "PERSONNEL" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4048d0fd-010a-4ecc-b02a-45c51bc86a32", "AQAAAAIAAYagAAAAEOyNy+qPic8sL5uv0YQFd2m6SDhq6PQy/FPMXxBzvEi3i8t87Jy4cMCpTEwId1ogrw==", "11ddce35-f4c9-4aab-bcff-07558e57ce3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22290567-8a17-443b-a7e1-b532286f1705", "AQAAAAIAAYagAAAAENzXxuupa4mqNH+iA7n1noVmAEbs8fKIEyoX8aiGk11M7GM7eWLpxoSDPc0NKoxDuA==", "71bd16c0-ccad-4980-b4a7-9f8b68adc57a" });
        }
    }
}
