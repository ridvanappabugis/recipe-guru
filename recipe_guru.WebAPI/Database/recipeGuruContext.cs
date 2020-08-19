using System;
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
                ImageByteValue = File.ReadAllBytes("img/supe.png")
            });

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 2,
                ImageByteValue = File.ReadAllBytes("img/dessert.png")
            });

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 3,
                ImageByteValue = File.ReadAllBytes("img/food.png")
            });

            // Slike Recepata

            // Desserts

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 4,
                ImageByteValue = File.ReadAllBytes("img/birthday.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 5,
                ImageByteValue = File.ReadAllBytes("img/musse.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 6,
                ImageByteValue = File.ReadAllBytes("img/nuts.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 7,
                ImageByteValue = File.ReadAllBytes("img/strawberry.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 8,
                ImageByteValue = File.ReadAllBytes("img/sugarbits.png")
            });

            // Soups

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 9,
                ImageByteValue = File.ReadAllBytes("img/chickensoup.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 10,
                ImageByteValue = File.ReadAllBytes("img/pastasoup.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 11,
                ImageByteValue = File.ReadAllBytes("img/vegetablesoup.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 12,
                ImageByteValue = File.ReadAllBytes("img/potatosoup.png")
            });


            // Food pictures

            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 13,
                ImageByteValue = File.ReadAllBytes("img/pasta.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 14,
                ImageByteValue = File.ReadAllBytes("img/pie.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 15,
                ImageByteValue = File.ReadAllBytes("img/doner.png")
            });


            modelBuilder.Entity<ImageResource>().HasData(new ImageResource()
            {
                Id = 16,
                ImageByteValue = File.ReadAllBytes("img/fish.png")
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

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 1,
                KnjigaRecepataId = 3,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Colorful Birthday Muffins",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 4
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 2,
                KnjigaRecepataId = 3,
                BrojPregleda = 0,
                DuzinaPripreme = 15,
                Naziv = "Chocolate Musse",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 5
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 3,
                KnjigaRecepataId = 3,
                BrojPregleda = 0,
                DuzinaPripreme = 20,
                Naziv = "Nuts Icecream",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 6
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 4,
                KnjigaRecepataId = 3,
                BrojPregleda = 0,
                DuzinaPripreme = 35,
                Naziv = "Strawberry Cake",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 7
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 5,
                KnjigaRecepataId = 3,
                BrojPregleda = 0,
                DuzinaPripreme = 10,
                Naziv = "Sugar Bits",
                Public = true,
                KategorijaId = 15,
                ImageResourceId = 8
            });

            // Soups

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 6,
                KnjigaRecepataId = 2,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Late Night Chicken Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 9
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 7,
                KnjigaRecepataId = 2,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Italian Pasta Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 10
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 8,
                KnjigaRecepataId = 2,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Sick Vegetables",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 11
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 9,
                KnjigaRecepataId = 2,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Grandmas Potato Soup",
                Public = true,
                KategorijaId = 7,
                ImageResourceId = 12
            });

            // Foods

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 10,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Italian Pasta Bolognese",
                Public = true,
                KategorijaId = 3,
                ImageResourceId = 13
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 11,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Southern Pie",
                Public = true,
                KategorijaId = 4,
                ImageResourceId = 14
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 12,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Turkish Ala Doner",
                Public = true,
                KategorijaId = 4,
                ImageResourceId = 15
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 13,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Grilled Fish",
                Public = true,
                KategorijaId = 8,
                ImageResourceId = 16
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

                Random random3 = new Random();
                modelBuilder.Entity<ReceptPregled>().HasData(new ReceptPregled()
                {

                    Id = receptPregledId++,
                    ReceptId = r,
                    BrojPregleda = random3.Next(14, 324)
                });
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
