using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace recipeguru.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageByteValue = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 500, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    UlogaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnjigeRecepata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Public = table.Column<bool>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnjigeRecepata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnjigeRecepata_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recepti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    BrojPregleda = table.Column<long>(nullable: false),
                    DuzinaPripreme = table.Column<int>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    GlavnaSlikaId = table.Column<int>(nullable: true),
                    KnjigaRecepataId = table.Column<int>(nullable: false),
                    KategorijeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepti_ImageResources_GlavnaSlikaId",
                        column: x => x.GlavnaSlikaId,
                        principalTable: "ImageResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recepti_Kategorije_KategorijeId",
                        column: x => x.KategorijeId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recepti_KnjigeRecepata_KnjigaRecepataId",
                        column: x => x.KnjigaRecepataId,
                        principalTable: "KnjigeRecepata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    InsertTime = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    ReceptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Recepti_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReceptKoraci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedniBrojKoraka = table.Column<int>(nullable: false),
                    Deskripcija = table.Column<string>(nullable: true),
                    ReceptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptKoraci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptKoraci_Recepti_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceptSastojci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    ReceptId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptSastojci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptSastojci_Recepti_ReceptId",
                        column: x => x.ReceptId,
                        principalTable: "Recepti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorije",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Hljebovi i Pekarska hrana" },
                    { 14, "Snacks" },
                    { 13, "Salate" },
                    { 12, "Sendvici" },
                    { 11, "Pizze" },
                    { 10, "Jela iz Lonca" },
                    { 8, "Glavna Jela" },
                    { 9, "Predjela" },
                    { 6, "Kokteli" },
                    { 5, "Umaci, Salate, Sosovi" },
                    { 4, "Rucak" },
                    { 3, "Vecera" },
                    { 2, "Dorucak" },
                    { 7, "Supe" }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 1, 0 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon", "UlogaId" },
                values: new object[] { 1, "ridvan@fit.ba", "Ridvan", "admin", "GBFHxSi0pxp8UvFBlOVB/buYmks=", "iqaMPG7eGDsk6NR6pZjiag==", "Appa", "061234567", 1 });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "Id", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon", "UlogaId" },
                values: new object[] { 2, "ridvanclient@fit.ba", "Ridvan", "ClientUser", "K2J0XqIuEhvmX6NPQ7A56/DcE+0=", "SNCXDc86Hu29XN51tHI4SQ==", "Appa", "061234567", 2 });

            migrationBuilder.InsertData(
                table: "KnjigeRecepata",
                columns: new[] { "Id", "KorisnikId", "Naziv", "Public" },
                values: new object[] { 1, 2, "Ridvanovi Recepti", true });

            migrationBuilder.InsertData(
                table: "KnjigeRecepata",
                columns: new[] { "Id", "KorisnikId", "Naziv", "Public" },
                values: new object[] { 2, 2, "Ridvanovi Recepti #2", false });

            migrationBuilder.InsertData(
                table: "Recepti",
                columns: new[] { "Id", "BrojPregleda", "DuzinaPripreme", "GlavnaSlikaId", "KategorijeId", "KnjigaRecepataId", "Naziv", "Public" },
                values: new object[] { 1, 0L, 30, null, 7, 1, "Domaci Nanin Grah", true });

            migrationBuilder.InsertData(
                table: "Recepti",
                columns: new[] { "Id", "BrojPregleda", "DuzinaPripreme", "GlavnaSlikaId", "KategorijeId", "KnjigaRecepataId", "Naziv", "Public" },
                values: new object[] { 2, 0L, 30, null, 4, 1, "Doner Kebab iz srca Turske", true });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Comment", "InsertTime", "KorisnikId", "Mark", "ReceptId" },
                values: new object[] { 1, "Predobar doner.", new DateTime(2020, 8, 10, 23, 43, 32, 866, DateTimeKind.Local).AddTicks(6630), 1, 4, 2 });

            migrationBuilder.InsertData(
                table: "ReceptKoraci",
                columns: new[] { "Id", "Deskripcija", "ReceptId", "RedniBrojKoraka" },
                values: new object[,]
                {
                    { 4, "Ubrati grah.", 1, 1 },
                    { 5, "Skuhati.", 1, 2 },
                    { 6, "Dodati suhog mesa.", 1, 3 },
                    { 1, "Priprema sosa za prekrivanje mesa.", 2, 1 },
                    { 2, "Przenje mesa.", 2, 2 },
                    { 3, "Jedenje.", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "ReceptSastojci",
                columns: new[] { "Id", "Kolicina", "Naziv", "ReceptId" },
                values: new object[,]
                {
                    { 1, "1 kilgoram", "Telece meso.", 2 },
                    { 2, "1 kilgoram", "Telece meso.", 2 },
                    { 3, "1 kilgoram", "Telece meso.", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnjigeRecepata_KorisnikId",
                table: "KnjigeRecepata",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "CS_Email",
                table: "Korisnici",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "CS_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaId",
                table: "Korisnici",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_KorisnikId",
                table: "Ratings",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ReceptId",
                table: "Ratings",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_GlavnaSlikaId",
                table: "Recepti",
                column: "GlavnaSlikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_KategorijeId",
                table: "Recepti",
                column: "KategorijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepti_KnjigaRecepataId",
                table: "Recepti",
                column: "KnjigaRecepataId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptKoraci_ReceptId",
                table: "ReceptKoraci",
                column: "ReceptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptSastojci_ReceptId",
                table: "ReceptSastojci",
                column: "ReceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ReceptKoraci");

            migrationBuilder.DropTable(
                name: "ReceptSastojci");

            migrationBuilder.DropTable(
                name: "Recepti");

            migrationBuilder.DropTable(
                name: "ImageResources");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "KnjigeRecepata");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
