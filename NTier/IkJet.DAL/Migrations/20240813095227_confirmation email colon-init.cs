using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkJet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class confirmationemailcoloninit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmationEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "ConfirmationEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4baff0ef-0a59-43a1-9500-1941438cfbfa", "admin@admin.com", "AQAAAAIAAYagAAAAEHGsn1kxUnGiF86cdXYExH83CXwQ2QTnAXmRIYzTF+oRAbxdmqAfdhIg+WuRaf/xeg==", "6f96440f-4f75-4ff6-9531-8298148446fc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationEmail",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a3bbe91-c5c8-40c3-9e6b-b786c23f07cf", "AQAAAAIAAYagAAAAEEro1pKA4RDF8Uo5qS9KPC/FRwbYY05Ub6M5xFGRtxJeWE/3+dxN06bxWv59YcbFdg==", "287696de-2884-4ffc-b05e-c202bbdca76b" });
        }
    }
}
