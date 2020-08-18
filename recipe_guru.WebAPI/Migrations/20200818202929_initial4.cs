using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recipeguru.WebAPI.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deskripcija",
                table: "Korisnici",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "KnjigeRecepata",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deskripcija",
                value: "Moji dobri recepti");

            migrationBuilder.UpdateData(
                table: "KnjigeRecepata",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deskripcija",
                value: "Bolji recepti");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "6/f94IHGn8wYm0yXQliS7IrQdVE=", "Zk8lh52QWfhIZqEqRbrbCw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "/afOy5jCN1/kmVDLQvtyXzHnkgk=", "nT+GQjhNoJSWDpULg/Gqqg==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2020, 8, 18, 22, 29, 29, 297, DateTimeKind.Local).AddTicks(2890));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deskripcija",
                table: "Korisnici");

            migrationBuilder.UpdateData(
                table: "KnjigeRecepata",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deskripcija",
                value: null);

            migrationBuilder.UpdateData(
                table: "KnjigeRecepata",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deskripcija",
                value: null);

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
    }
}
