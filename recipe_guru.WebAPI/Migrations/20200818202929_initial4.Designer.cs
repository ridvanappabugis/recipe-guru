﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using recipe_guru.WebAPI.Database;

namespace recipeguru.WebAPI.Migrations
{
    [DbContext(typeof(recipeGuruContext))]
    [Migration("20200818202929_initial4")]
    partial class initial4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("recipe_guru.WebAPI.Database.ImageResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageByteValue")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageResources");
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorije");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Hljebovi i Pekarska hrana"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Dorucak"
                        },
                        new
                        {
                            Id = 3,
                            Naziv = "Vecera"
                        },
                        new
                        {
                            Id = 4,
                            Naziv = "Rucak"
                        },
                        new
                        {
                            Id = 5,
                            Naziv = "Umaci, Salate, Sosovi"
                        },
                        new
                        {
                            Id = 6,
                            Naziv = "Kokteli"
                        },
                        new
                        {
                            Id = 7,
                            Naziv = "Supe"
                        },
                        new
                        {
                            Id = 8,
                            Naziv = "Glavna Jela"
                        },
                        new
                        {
                            Id = 9,
                            Naziv = "Predjela"
                        },
                        new
                        {
                            Id = 10,
                            Naziv = "Jela iz Lonca"
                        },
                        new
                        {
                            Id = 11,
                            Naziv = "Pizze"
                        },
                        new
                        {
                            Id = 12,
                            Naziv = "Sendvici"
                        },
                        new
                        {
                            Id = 13,
                            Naziv = "Salate"
                        },
                        new
                        {
                            Id = 14,
                            Naziv = "Snacks"
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.KnjigaRecepata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageResouceId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageResourceId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Public")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImageResourceId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("KnjigeRecepata");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deskripcija = "Moji dobri recepti",
                            ImageResouceId = 0,
                            KorisnikId = 2,
                            Naziv = "Ridvanovi Recepti",
                            Public = true
                        },
                        new
                        {
                            Id = 2,
                            Deskripcija = "Bolji recepti",
                            ImageResouceId = 0,
                            KorisnikId = 2,
                            Naziv = "Ridvanovi Recepti #2",
                            Public = false
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("CS_Email")
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique()
                        .HasName("CS_KorisnickoIme");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnici");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ridvan@fit.ba",
                            Ime = "Ridvan",
                            KorisnickoIme = "admin",
                            LozinkaHash = "6/f94IHGn8wYm0yXQliS7IrQdVE=",
                            LozinkaSalt = "Zk8lh52QWfhIZqEqRbrbCw==",
                            Prezime = "Appa",
                            Telefon = "061234567",
                            UlogaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "ridvanclient@fit.ba",
                            Ime = "Ridvan",
                            KorisnickoIme = "ClientUser",
                            LozinkaHash = "/afOy5jCN1/kmVDLQvtyXzHnkgk=",
                            LozinkaSalt = "nT+GQjhNoJSWDpULg/Gqqg==",
                            Prezime = "Appa",
                            Telefon = "061234567",
                            UlogaId = 2
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("ReceptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ReceptId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Predobar doner.",
                            InsertTime = new DateTime(2020, 8, 18, 22, 29, 29, 297, DateTimeKind.Local).AddTicks(2890),
                            KorisnikId = 1,
                            Mark = 4,
                            ReceptId = 2
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Recept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BrojPregleda")
                        .HasColumnType("bigint");

                    b.Property<int>("DuzinaPripreme")
                        .HasColumnType("int");

                    b.Property<int>("ImageResouceId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageResourceId")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<int>("KnjigaRecepataId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Public")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImageResourceId");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("KnjigaRecepataId");

                    b.ToTable("Recepti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrojPregleda = 0L,
                            DuzinaPripreme = 30,
                            ImageResouceId = 0,
                            KategorijaId = 7,
                            KnjigaRecepataId = 1,
                            Naziv = "Domaci Nanin Grah",
                            Public = true
                        },
                        new
                        {
                            Id = 2,
                            BrojPregleda = 0L,
                            DuzinaPripreme = 30,
                            ImageResouceId = 0,
                            KategorijaId = 4,
                            KnjigaRecepataId = 1,
                            Naziv = "Doner Kebab iz srca Turske",
                            Public = true
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.ReceptKorak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageResouceId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageResourceId")
                        .HasColumnType("int");

                    b.Property<int>("ReceptId")
                        .HasColumnType("int");

                    b.Property<int>("RedniBrojKoraka")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageResourceId");

                    b.HasIndex("ReceptId");

                    b.ToTable("ReceptKoraci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deskripcija = "Priprema sosa za prekrivanje mesa.",
                            ImageResouceId = 0,
                            ReceptId = 2,
                            RedniBrojKoraka = 1
                        },
                        new
                        {
                            Id = 2,
                            Deskripcija = "Przenje mesa.",
                            ImageResouceId = 0,
                            ReceptId = 2,
                            RedniBrojKoraka = 2
                        },
                        new
                        {
                            Id = 3,
                            Deskripcija = "Jedenje.",
                            ImageResouceId = 0,
                            ReceptId = 2,
                            RedniBrojKoraka = 3
                        },
                        new
                        {
                            Id = 4,
                            Deskripcija = "Ubrati grah.",
                            ImageResouceId = 0,
                            ReceptId = 1,
                            RedniBrojKoraka = 1
                        },
                        new
                        {
                            Id = 5,
                            Deskripcija = "Skuhati.",
                            ImageResouceId = 0,
                            ReceptId = 1,
                            RedniBrojKoraka = 2
                        },
                        new
                        {
                            Id = 6,
                            Deskripcija = "Dodati suhog mesa.",
                            ImageResouceId = 0,
                            ReceptId = 1,
                            RedniBrojKoraka = 3
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.ReceptSastojak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kolicina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceptId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceptId");

                    b.ToTable("ReceptSastojci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Kolicina = "1 kilgoram",
                            Naziv = "Telece meso.",
                            ReceptId = 2
                        },
                        new
                        {
                            Id = 2,
                            Kolicina = "1 kilgoram",
                            Naziv = "Telece meso.",
                            ReceptId = 2
                        },
                        new
                        {
                            Id = 3,
                            Kolicina = "1 kilgoram",
                            Naziv = "Telece meso.",
                            ReceptId = 2
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Naziv")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Uloge");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = 0
                        },
                        new
                        {
                            Id = 2,
                            Naziv = 2
                        },
                        new
                        {
                            Id = 3,
                            Naziv = 1
                        });
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.KnjigaRecepata", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.ImageResource", "ImageResource")
                        .WithMany()
                        .HasForeignKey("ImageResourceId");

                    b.HasOne("recipe_guru.WebAPI.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Korisnik", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Rating", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_guru.WebAPI.Database.Recept", "Recept")
                        .WithMany("Ratings")
                        .HasForeignKey("ReceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.Recept", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.ImageResource", "ImageResource")
                        .WithMany()
                        .HasForeignKey("ImageResourceId");

                    b.HasOne("recipe_guru.WebAPI.Database.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("recipe_guru.WebAPI.Database.KnjigaRecepata", "KnjigaRecepata")
                        .WithMany("Recepti")
                        .HasForeignKey("KnjigaRecepataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.ReceptKorak", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.ImageResource", "ImageResource")
                        .WithMany()
                        .HasForeignKey("ImageResourceId");

                    b.HasOne("recipe_guru.WebAPI.Database.Recept", "Recept")
                        .WithMany("ReceptKoraci")
                        .HasForeignKey("ReceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("recipe_guru.WebAPI.Database.ReceptSastojak", b =>
                {
                    b.HasOne("recipe_guru.WebAPI.Database.Recept", "Recept")
                        .WithMany("ReceptSastojci")
                        .HasForeignKey("ReceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
