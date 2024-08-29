using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IkJet.DAL.Migrations
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
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Personnel", "PERSONNEL" },
                    { 3, null, "HRManager", "HRMANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "BirthPlace", "CompanyId", "CompanyName", "ConcurrencyStamp", "ConfirmationEmail", "Department", "Email", "EmailConfirmed", "FirstName", "HireDate", "ImageName", "IsActive", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecondLastName", "SecondName", "SecurityStamp", "TCIdentityNumber", "TerminationDate", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "admin", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", null, "admin", "d5c84647-b45b-4298-a565-20d8ec4ae20c", "admin@admin.com", "admin", "admin@mail.com", true, "adminName", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", true, "admin", "adminSurname", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFRT+7NrXOktsKi5g7IMiCc4MLItEJcrNCGi6cI1jJNOGLe0SNS+pCZGHQySu/QuSA==", "-", true, 1.0, "adminSecondLastName", "adminSecondName", "a9871d59-829c-4c95-9fda-38db1d3ba6f2", "12345678901", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
