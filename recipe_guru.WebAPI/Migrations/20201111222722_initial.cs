using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recipe_guru.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageResourceId",
                table: "Korisnici",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "PH2Mg5g7/nHFtMb7TaDiBXG/AZo=", "eQ4yoYPFbaEG7exePDKYLw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "+suIFXkogvUydv9Cylh1dXHEktE=", "vODy5QE3dqT/MPgsETZ5fQ==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Just like grandma used to make.", new DateTime(2020, 11, 11, 23, 27, 21, 280, DateTimeKind.Local).AddTicks(7957), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Had better.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(6555), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(6640), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(7201), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(7282) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Just like grandma used to make.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(7749), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Good Recipe! Had fun making it.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(7822), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InsertTime", "Mark" },
                values: new object[] { new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(8378), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Had better.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(8491), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Satisfactory, Could be better.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "My mom likes to eat this, so it makes me happy making it for her.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Just like grandma used to make.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.", new DateTime(2020, 11, 11, 23, 27, 21, 286, DateTimeKind.Local).AddTicks(9648), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Good Recipe! Had fun making it.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Good Recipe! Had fun making it.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(184), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(797), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "My mom likes to eat this, so it makes me happy making it for her.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(876), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Had better.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(3697), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(3801), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(4271), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Good Recipe! Had fun making it.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(4342), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Satisfactory, Could be better.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(4885), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(5492) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Had better.", new DateTime(2020, 11, 11, 23, 27, 21, 287, DateTimeKind.Local).AddTicks(5565), 3 });

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrojPregleda",
                value: 128);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrojPregleda",
                value: 216);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 3,
                column: "BrojPregleda",
                value: 232);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 4,
                column: "BrojPregleda",
                value: 50);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 5,
                column: "BrojPregleda",
                value: 75);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 6,
                column: "BrojPregleda",
                value: 173);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 7,
                column: "BrojPregleda",
                value: 307);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 8,
                column: "BrojPregleda",
                value: 247);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 9,
                column: "BrojPregleda",
                value: 308);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 10,
                column: "BrojPregleda",
                value: 171);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 11,
                column: "BrojPregleda",
                value: 178);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 12,
                column: "BrojPregleda",
                value: 99);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 13,
                column: "BrojPregleda",
                value: 284);

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "107", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "95", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "99", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "99", "Flour" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "120", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "33", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "51", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "79", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "179", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "31", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "122", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "170", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "192", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "76", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "95", "Chili Powder" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "149", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "149", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 18,
                column: "Kolicina",
                value: "143");

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "165", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "130", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "118", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "93", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "42", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "115", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "13", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "9", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "10", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "139", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "64", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "82", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "171", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "45", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "153", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "123", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "4", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "4", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "7", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "28", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "198", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "154", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "16", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "21", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "72", "Water" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "186", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "79", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "134", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "60", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "159", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "143", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "161", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 51,
                column: "Kolicina",
                value: "163");

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "59", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "106", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "78", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "139", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "104", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "123", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "51", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "135", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "189", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "133", "Chili Powder" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "98", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "33", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "160", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "62", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "72", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "84", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "46", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "13", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "23", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "148", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "93", "Chili Powder" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "164", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "18", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "125", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "187", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "184", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "29", "Sugar" });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_ImageResourceId",
                table: "Korisnici",
                column: "ImageResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_ImageResources_ImageResourceId",
                table: "Korisnici",
                column: "ImageResourceId",
                principalTable: "ImageResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_ImageResources_ImageResourceId",
                table: "Korisnici");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_ImageResourceId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "ImageResourceId",
                table: "Korisnici");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "rw4ASH0jpNtjVMWnwz0W9G6gQV4=", "ERO7w+hToRVJHAy/yu0Epg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "037WucKwauVsQsUe15sbpWkWpQM=", "dqajfq/QCcekGcncbzomgg==" });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 8, 19, 22, 8, 17, 543, DateTimeKind.Local).AddTicks(1620), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(3060), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(3120), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(3510), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4000), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Satisfactory, Could be better.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4050), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "InsertTime", "Mark" },
                values: new object[] { new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4360), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "My mom likes to eat this, so it makes me happy making it for her.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4440), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Good Recipe! Had fun making it.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Satisfactory, Could be better.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Had better.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5240), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Had better.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Just like grandma used to make.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5590), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "My mom likes to eat this, so it makes me happy making it for her.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5930), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Just like grandma used to make.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(5980), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(6280), 3 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(6330), 2 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "My mom likes to eat this, so it makes me happy making it for her.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(6750), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(6800), 0 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(7150), 4 });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "I had better in a 5-star restaurant.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Comment", "InsertTime" },
                values: new object[] { "Best eat of my life.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Comment", "InsertTime", "Mark" },
                values: new object[] { "Easy! My Kids loved it.", new DateTime(2020, 8, 19, 22, 8, 17, 550, DateTimeKind.Local).AddTicks(7540), 4 });

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrojPregleda",
                value: 63);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrojPregleda",
                value: 235);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 3,
                column: "BrojPregleda",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 4,
                column: "BrojPregleda",
                value: 23);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 5,
                column: "BrojPregleda",
                value: 112);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 6,
                column: "BrojPregleda",
                value: 134);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 7,
                column: "BrojPregleda",
                value: 161);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 8,
                column: "BrojPregleda",
                value: 34);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 9,
                column: "BrojPregleda",
                value: 133);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 10,
                column: "BrojPregleda",
                value: 250);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 11,
                column: "BrojPregleda",
                value: 125);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 12,
                column: "BrojPregleda",
                value: 312);

            migrationBuilder.UpdateData(
                table: "ReceptPregledi",
                keyColumn: "Id",
                keyValue: 13,
                column: "BrojPregleda",
                value: 100);

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "125", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "121", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "197", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "83", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "181", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "134", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "71", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "159", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "117", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "53", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "84", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "6", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "38", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "60", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "19", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "133", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "96", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 18,
                column: "Kolicina",
                value: "36");

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "137", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "138", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "165", "Water" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "172", "Flour" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "26", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "53", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "161", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "119", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "61", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "87", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "175", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "199", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "196", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "68", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "109", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "127", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "127", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "100", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "22", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "160", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "53", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "191", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "43", "Water" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "75", "Flour" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "43", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "66", "Chili Powder" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "91", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "188", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "115", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "163", "Chicken Drumsticks" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "172", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "57", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 51,
                column: "Kolicina",
                value: "37");

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "110", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "91", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "43", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "10", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "82", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "82", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "172", "Seasoning" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "72", "Sugar" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "42", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "151", "Spice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "155", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "96", "Coconut" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "11", "Potato" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "145", "Chocolate" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "86", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "182", "Cream" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "170", "Eggs" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "189", "Carrots" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "55", "Water" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "54", "Butter" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "152", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "185", "Ice" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "91", "Salt" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "99", "Cooking Oil" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "17", "Milk" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "10", "Water" });

            migrationBuilder.UpdateData(
                table: "ReceptSastojci",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Kolicina", "Naziv" },
                values: new object[] { "168", "Eggs" });
        }
    }
}
