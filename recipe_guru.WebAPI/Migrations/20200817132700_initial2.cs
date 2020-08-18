using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recipeguru.WebAPI.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepti_ImageResources_GlavnaSlikaId",
                table: "Recepti");

            migrationBuilder.DropIndex(
                name: "IX_Recepti_GlavnaSlikaId",
                table: "Recepti");

            migrationBuilder.DropColumn(
                name: "GlavnaSlikaId",
                table: "Recepti");

            migrationBuilder.AddColumn<int>(
                name: "ImageResouceId",
                table: "ReceptKoraci",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageResourceId",
                table: "ReceptKoraci",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageResouceId",
                table: "Recepti",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageResourceId",
                table: "Recepti",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageResouceId",
                table: "KnjigeRecepata",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageResourceId",
                table: "KnjigeRecepata",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ReceptKoraci_ImageResourceId",
                table: "ReceptKoraci",
                column: "ImageResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_ImageResourceId",
                table: "Recepti",
                column: "ImageResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeRecepata_ImageResourceId",
                table: "KnjigeRecepata",
                column: "ImageResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnjigeRecepata_ImageResources_ImageResourceId",
                table: "KnjigeRecepata",
                column: "ImageResourceId",
                principalTable: "ImageResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recepti_ImageResources_ImageResourceId",
                table: "Recepti",
                column: "ImageResourceId",
                principalTable: "ImageResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceptKoraci_ImageResources_ImageResourceId",
                table: "ReceptKoraci",
                column: "ImageResourceId",
                principalTable: "ImageResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnjigeRecepata_ImageResources_ImageResourceId",
                table: "KnjigeRecepata");

            migrationBuilder.DropForeignKey(
                name: "FK_Recepti_ImageResources_ImageResourceId",
                table: "Recepti");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceptKoraci_ImageResources_ImageResourceId",
                table: "ReceptKoraci");

            migrationBuilder.DropIndex(
                name: "IX_ReceptKoraci_ImageResourceId",
                table: "ReceptKoraci");

            migrationBuilder.DropIndex(
                name: "IX_Recepti_ImageResourceId",
                table: "Recepti");

            migrationBuilder.DropIndex(
                name: "IX_KnjigeRecepata_ImageResourceId",
                table: "KnjigeRecepata");

            migrationBuilder.DropColumn(
                name: "ImageResouceId",
                table: "ReceptKoraci");

            migrationBuilder.DropColumn(
                name: "ImageResourceId",
                table: "ReceptKoraci");

            migrationBuilder.DropColumn(
                name: "ImageResouceId",
                table: "Recepti");

            migrationBuilder.DropColumn(
                name: "ImageResourceId",
                table: "Recepti");

            migrationBuilder.DropColumn(
                name: "ImageResouceId",
                table: "KnjigeRecepata");

            migrationBuilder.DropColumn(
                name: "ImageResourceId",
                table: "KnjigeRecepata");

            migrationBuilder.AddColumn<int>(
                name: "GlavnaSlikaId",
                table: "Recepti",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Id4Z8QPOmgazi9b+QZGBELqSpl0=", "9mlcua6FN/zddKAYy382rg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "xE3FiDu0z9nIs26CWCNL2V1g2og=", "y/e6wUiyOrPgXtWPlCg8dw==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2020, 8, 11, 0, 58, 56, 932, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_GlavnaSlikaId",
                table: "Recepti",
                column: "GlavnaSlikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepti_ImageResources_GlavnaSlikaId",
                table: "Recepti",
                column: "GlavnaSlikaId",
                principalTable: "ImageResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
