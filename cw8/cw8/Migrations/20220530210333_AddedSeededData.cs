using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw8.Migrations
{
    public partial class AddedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "anowak@gmail.com", "Andrzej", "Nowak" },
                    { 2, "kjaki@gmail.com", "Krzysztof", "Jaki" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Paracetamol 100mg", "Apap", "na ból zęba" },
                    { 2, "Paracetamol 200mg", "Apap Extra", "na ból głowy" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", "Blok" },
                    { 2, new DateTime(2001, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mateusz", "Kowalski" },
                    { 3, new DateTime(2001, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamil", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2022, 5, 30, 23, 3, 32, 642, DateTimeKind.Local).AddTicks(4927), new DateTime(2022, 7, 1, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(6110), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2022, 5, 30, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(6991), new DateTime(2022, 8, 10, 23, 3, 32, 644, DateTimeKind.Local).AddTicks(7003), 2, 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 1, 1, "brać 1 tabletke rano i wieczorem", 100 });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 2, 2, "brać 1 tabletke rano i wieczorem", 200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);
        }
    }
}
