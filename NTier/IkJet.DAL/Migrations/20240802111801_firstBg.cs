using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkJet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class firstBg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22290567-8a17-443b-a7e1-b532286f1705", "AQAAAAIAAYagAAAAENzXxuupa4mqNH+iA7n1noVmAEbs8fKIEyoX8aiGk11M7GM7eWLpxoSDPc0NKoxDuA==", "71bd16c0-ccad-4980-b4a7-9f8b68adc57a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfa46af4-d06a-4361-8c2d-24cce1e450b2", "AQAAAAIAAYagAAAAEDEAc8TiB+89R9o+qMyVTAmCGVaKjjoXfsWV5uoLYtVu9HvvZnqDXo3euXO4KvQeGQ==", "d0c05101-e444-44a3-9eca-f26fd4ef5e87" });
        }
    }
}
