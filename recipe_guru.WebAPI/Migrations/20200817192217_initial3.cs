using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recipeguru.WebAPI.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deskripcija",
                table: "KnjigeRecepata",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "30E/XPWSeEOH9YhukBLkwrrgFsw=", "PpDxuwnEIRd+M2EmI20hEw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "mOSj886OvPlWI5TJ/n5Pjm0Ac70=", "EgSammD4rBZug7iixCtsbg==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2020, 8, 17, 21, 22, 16, 687, DateTimeKind.Local).AddTicks(5480));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deskripcija",
                table: "KnjigeRecepata");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "g4cBZyS7PNkhe4xkBPM2+48P8QY=", "D0pIC0nkm+PlUsUfUay7Mw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "nbRaVDOc/GeDKTH34ItqL99vTX8=", "q2YzFZlXnuqpc4w0A/r5UQ==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2020, 8, 17, 15, 26, 59, 684, DateTimeKind.Local).AddTicks(3500));
        }
    }
}
