using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw8.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 16, 19, 16, 33, 603, DateTimeKind.Local).AddTicks(7602), new DateTime(2022, 7, 18, 19, 16, 33, 605, DateTimeKind.Local).AddTicks(8627) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 6, 16, 19, 16, 33, 605, DateTimeKind.Local).AddTicks(9515), new DateTime(2022, 8, 27, 19, 16, 33, 605, DateTimeKind.Local).AddTicks(9528) });

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 5, 30, 23, 3, 32, 642, DateTimeKind.Local).AddTicks(4927), new DateTime(2022, 7, 1, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2022, 5, 30, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(6991), new DateTime(2022, 8, 10, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(7003) });
        }
    }
}
