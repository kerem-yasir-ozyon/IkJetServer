using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkJet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2h : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15189ef-2b01-4d46-b1cb-4793d8b5f3a5", "AQAAAAIAAYagAAAAEJOBEYzVIHcjCtXFMhtfX3c7zPn7drQdLiN47vUusof1Wdx3rQ02jSA3jTeOiKe7bg==", "c39bbc96-082f-4d73-86ef-5e0e98a002a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4048d0fd-010a-4ecc-b02a-45c51bc86a32", "AQAAAAIAAYagAAAAEOyNy+qPic8sL5uv0YQFd2m6SDhq6PQy/FPMXxBzvEi3i8t87Jy4cMCpTEwId1ogrw==", "11ddce35-f4c9-4aab-bcff-07558e57ce3b" });
        }
    }
}
