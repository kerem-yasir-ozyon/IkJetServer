using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkJet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class HRManagerRoleInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, null, "HRManager", "HRMANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a3bbe91-c5c8-40c3-9e6b-b786c23f07cf", "AQAAAAIAAYagAAAAEEro1pKA4RDF8Uo5qS9KPC/FRwbYY05Ub6M5xFGRtxJeWE/3+dxN06bxWv59YcbFdg==", "287696de-2884-4ffc-b05e-c202bbdca76b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15189ef-2b01-4d46-b1cb-4793d8b5f3a5", "AQAAAAIAAYagAAAAEJOBEYzVIHcjCtXFMhtfX3c7zPn7drQdLiN47vUusof1Wdx3rQ02jSA3jTeOiKe7bg==", "c39bbc96-082f-4d73-86ef-5e0e98a002a0" });
        }
    }
}
