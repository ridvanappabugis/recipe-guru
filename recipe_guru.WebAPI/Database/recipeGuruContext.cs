﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using recipe_guru.WebAPI.Util;

namespace recipe_guru.WebAPI.Database
{
    public partial class recipeGuruContext : DbContext
    {
        public recipeGuruContext()
        {
        }

        public recipeGuruContext(DbContextOptions<recipeGuruContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Uloga> Uloge { get; set; }
        public virtual DbSet<ImageResource> ImageResources { get; set; }
        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<KnjigaRecepata> KnjigeRecepata { get; set; }
        public virtual DbSet<Recept> Recepti { get; set; }
        public virtual DbSet<ReceptKorak> ReceptKoraci { get; set; }
        public virtual DbSet<ReceptSastojak> ReceptSastojci { get; set; }
        public virtual DbSet<ReceptPregled> ReceptPregledi { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=RecipeGuru;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        void InitialiseData(ModelBuilder modelBuilder)
        {
            // user types
            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 1,
                Naziv = Role.ADMIN
            });

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 2,
                Naziv = Role.USER
            });

            // admin
            Korisnik u1 = new Korisnik
            {
                Id = 1,
                UlogaId = 1,
                KorisnickoIme = "AdminTest",
                Telefon = "061234567",
                Ime = "Admin",
                Prezime = "Adminovic",
                Email = "admin@fit.ba",
            };

            u1.LozinkaSalt = PasswordUtil.GenerateSalt();
            u1.LozinkaHash = PasswordUtil.GenerateHash(u1.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnik>().HasData(u1);

            // client user
            Korisnik u2 = new Korisnik
            {
                Id = 2,
                UlogaId = 2,
                KorisnickoIme = "UserTest",
                Telefon = "061234567",
                Ime = "User",
                Prezime = "Usercic",
                Email = "user@fit.ba",
            };

            u2.LozinkaSalt = PasswordUtil.GenerateSalt();
            u2.LozinkaHash = PasswordUtil.GenerateHash(u2.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnik>().HasData(u2);

            List<string> kategorije = new List<string> {
                "Breads and Flour Based Recipes",
                "Breakfast",
                "Dinner",
                "Supper",
                "Salsas, Salads",
                "Coctels",
                "Soups",
                "Main Courses",
                "Appetiser",
                "Meals on Wheels",
                "Pizzas",
                "Sandwiches",
                "Salads",
                "Snacks",
                "Desserts"
            };

            int i = 1;
            foreach (string kategorija in kategorije)
            {
                modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
                {
                    Id = i++,
                    Naziv = kategorija
                });
            }


            // Slike Knjiga

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 1,
                ImageByteValue = File.ReadAllBytes("img/supe.jpg")
            });

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 2,
                ImageByteValue = File.ReadAllBytes("img/dessert.jpg")
            });

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 3,
                ImageByteValue = File.ReadAllBytes("img/food.jpg")
            });

            // Slike Recepata

            // Desserts

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 4,
                ImageByteValue = File.ReadAllBytes("img/birthday.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 5,
                ImageByteValue = File.ReadAllBytes("img/musse.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 6,
                ImageByteValue = File.ReadAllBytes("img/nuts.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 7,
                ImageByteValue = File.ReadAllBytes("img/strawberry.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 8,
                ImageByteValue = File.ReadAllBytes("img/sugarbits.jpg")
            });

            // Soups

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 9,
                ImageByteValue = File.ReadAllBytes("img/chickensoup.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 10,
                ImageByteValue = File.ReadAllBytes("img/pastasoup.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 11,
                ImageByteValue = File.ReadAllBytes("img/vegetablesoup.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 12,
                ImageByteValue = File.ReadAllBytes("img/potatosoup.jpg")
            });


            // Food pictures

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 13,
                ImageByteValue = File.ReadAllBytes("img/pasta.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 14,
                ImageByteValue = File.ReadAllBytes("img/pie.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 15,
                ImageByteValue = File.ReadAllBytes("img/doner.jpg")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 16,
                ImageByteValue = File.ReadAllBytes("img/fish.jpg")
            });

            // Knjige Recepata

            modelBuilder.Entity<KnjigaRecepata>().HasData(new KnjigaRecepata()
            {
                Id = 1,
                KorisnikId = 2,
                Naziv = "5 Delicious Recipes",
                Deskripcija = "Recipes to die for",
                Public = true,
                ImageResourceId = 3
            });

            modelBuilder.Entity<KnjigaRecepata>().HasData(new KnjigaRecepata()
            {
                Id = 2,
                KorisnikId = 2,
                Naziv = "Best Soups For a Party",
                Deskripcija = "Soups a la grande",
                Public = true,
                ImageResourceId = 1
            });

            modelBuilder.Entity<KnjigaRecepata>().HasData(new KnjigaRecepata()
            {
                Id = 3,
                KorisnikId = 2,
                Naziv = "Desserts",
                Deskripcija = "Always leaves you wanting more",
                Public = true,
                ImageResourceId = 2
                
            });

            // Recepti

            // Desserts

            Random random3 = new Random();
            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 1,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 1,
                KnjigaRecepataId = 3,
                DuzinaPripreme = 30,
                Naziv = "Colorful Birthday Muffins",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 4,
                ReceptPregledId = 1
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 2,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 2,
                KnjigaRecepataId = 3,
                DuzinaPripreme = 15,
                Naziv = "Chocolate Musse",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 5,
                ReceptPregledId = 2
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 3,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 3,
                KnjigaRecepataId = 3,
                DuzinaPripreme = 20,
                Naziv = "Nuts Icecream",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 6,
                ReceptPregledId = 3
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 4,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 4,
                KnjigaRecepataId = 3,
                DuzinaPripreme = 35,
                Naziv = "Strawberry Cake",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 7,
                ReceptPregledId = 4
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 5,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 5,
                KnjigaRecepataId = 3,
                DuzinaPripreme = 10,
                Naziv = "Sugar Bits",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 8,
                ReceptPregledId = 5
            });

            // Soups
            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 6,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 6,
                KnjigaRecepataId = 2,
                DuzinaPripreme = 30,
                Naziv = "Late Night Chicken Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 9,
                ReceptPregledId = 6
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 7,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 7,
                KnjigaRecepataId = 2,
                DuzinaPripreme = 30,
                Naziv = "Italian Pasta Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 10,
                ReceptPregledId = 7
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 8,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 8,
                KnjigaRecepataId = 2,
                DuzinaPripreme = 30,
                Naziv = "Sick Vegetables",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 11,
                ReceptPregledId = 8
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 9,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 9,
                KnjigaRecepataId = 2,
                DuzinaPripreme = 30,
                Naziv = "Grandmas Potato Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 12,
                ReceptPregledId = 9
            });

            // Foods
            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 10,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 10,
                KnjigaRecepataId = 1,
                DuzinaPripreme = 30,
                Naziv = "Italian Pasta Bolognese",
                Public = true,
                KategorijaId = 3,
                ImageResourceId = 13,
                ReceptPregledId = 10
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 11,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 11,
                KnjigaRecepataId = 1,
                DuzinaPripreme = 30,
                Naziv = "Southern Pie",
                Public = true,
                KategorijaId = 4,
                ImageResourceId = 14,
                ReceptPregledId = 11
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 12,
                BrojPregleda = random3.Next(14, 324)
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 12,
                KnjigaRecepataId = 1,
                DuzinaPripreme = 30,
                Naziv = "Turkish Ala Doner",
                Public = true,
                KategorijaId = 4,
                ImageResourceId = 15,
                ReceptPregledId = 12
            });

            modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
            {
                Id = 13,
                BrojPregleda = random3.Next(14, 324)
            });
            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 13,
                KnjigaRecepataId = 1,
                DuzinaPripreme = 30,
                Naziv = "Grilled Fish",
                Public = true,
                KategorijaId = 8,
                ImageResourceId = 16,
                ReceptPregledId = 13
            });

            List<string> sastojci = new List<string> {
                "Flour",
                "Eggs",
                "Water",
                "Sugar",
                "Salt",
                "Spice",
                "Chili Powder",
                "Seasoning",
                "Butter",
                "Potato",
                "Milk",
                "Cooking Oil",
                "Cream",
                "Chocolate",
                "Coconut",
                "Ice",
                "Chicken Drumsticks",
                "Carrots",
                "Paprika"
            };

            List<string> ratings = new List<string> {
                "Good Recipe! Had fun making it.",
                "Easy! My Kids loved it.",
                "Satisfactory, Could be better.",
                "I had a blast eating this, but the cooking recipe could use some description on how to cook this in a technical way.",
                "Best eat of my life.",
                "Had better.",
                "Just like grandma used to make.",
                "I had better in a 5-star restaurant.",
                "My mom likes to eat this, so it makes me happy making it for her.",
                "I like trains."
            };

            List<RatingMark> marks = new List<RatingMark> { RatingMark.ONE_STAR, RatingMark.FOUR_STAR, RatingMark.FIVE_STAR, RatingMark.THREE_STAR, RatingMark.TWO_STAR };

            int receptSastojakId = 1;
            int receptReviewId = 1;
            int receptPregledId = 1;
            for (int r = 1; r<14; r++)
            {
                // Sastojci
                for (int j = 1; j<7; j++)
                {
                    Random random1 = new Random();
                    modelBuilder.Entity<ReceptSastojak>().HasData(new ReceptSastojak()
                    {
                        Id = receptSastojakId++,
                        ReceptId = r,
                        Kolicina = random1.Next(1, 200) + "",
                        Naziv = sastojci[random1.Next(0,18)]
                    });
                }

                // Ratings

                for (int j = 1; j < 3; j++)
                {
                    Random random2 = new Random();
                    modelBuilder.Entity<Rating>().HasData(new Rating()
                    {
                        Id = receptReviewId++,
                        ReceptId = r,
                        InsertTime = System.DateTime.Now,
                        KorisnikId = 2,
                        Mark = marks[random2.Next(0,4)],
                        Comment = ratings[random2.Next(0,9)]
                    });
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Email)
                    .HasName("CS_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme)
                    .HasName("CS_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Telefon).HasMaxLength(20);
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            InitialiseData(modelBuilder);
        }
    }
}
