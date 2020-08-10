using System;
using System.Collections.Generic;
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

        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<ImageResources> ImageResources { get; set; }
        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<KnjigeRecepata> KnjigeRecepata { get; set; }
        public virtual DbSet<Recepti> Recepti { get; set; }
        public virtual DbSet<ReceptKoraci> ReceptKoraci { get; set; }
        public virtual DbSet<ReceptSastojci> ReceptSastojci { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=recipeGuru;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        void InitialiseData(ModelBuilder modelBuilder)
        {
            // user types
            modelBuilder.Entity<Uloge>().HasData(new Uloge()
            {
                Id = 1,
                Naziv = Role.ADMIN
            });

            modelBuilder.Entity<Uloge>().HasData(new Uloge()
            {
                Id = 2,
                Naziv = Role.USER
            });

            modelBuilder.Entity<Uloge>().HasData(new Uloge()
            {
                Id = 3,
                Naziv = Role.VISITOR
            });

            // admin
            Korisnici u1 = new Korisnici
            {
                Id = 1,
                UlogaId = 1,
                KorisnickoIme = "admin",
                Telefon = "061234567",
                Ime = "Ridvan",
                Prezime = "Appa",
                Email = "ridvan@fit.ba",
            };

            u1.LozinkaSalt = PasswordUtil.GenerateSalt();
            u1.LozinkaHash = PasswordUtil.GenerateHash(u1.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnici>().HasData(u1);

            // client user
            Korisnici u2 = new Korisnici
            {
                Id = 2,
                UlogaId = 2,
                KorisnickoIme = "ClientUser",
                Telefon = "061234567",
                Ime = "Ridvan",
                Prezime = "Appa",
                Email = "ridvanclient@fit.ba",
            };

            u2.LozinkaSalt = PasswordUtil.GenerateSalt();
            u2.LozinkaHash = PasswordUtil.GenerateHash(u2.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnici>().HasData(u2);

            List<string> kategorije = new List<string> {
                "Hljebovi i Pekarska hrana",
                "Dorucak",
                "Vecera",
                "Rucak",
                "Umaci, Salate, Sosovi",
                "Kokteli",
                "Supe",
                "Glavna Jela",
                "Predjela",
                "Jela iz Lonca",
                "Pizze",
                "Sendvici",
                "Salate",
                "Snacks"
            };

            int i = 1;

            foreach (string kategorija in kategorije)
            {
                modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
                {
                    Id = i++,
                    Naziv = kategorija
                });
            }

            modelBuilder.Entity<KnjigeRecepata>().HasData(new KnjigeRecepata()
            {
                Id = 1,
                KorisnikId = 2,
                Naziv = "Ridvanovi Recepti",
                Public = true
            });

            modelBuilder.Entity<KnjigeRecepata>().HasData(new KnjigeRecepata()
            {
                Id = 2,
                KorisnikId = 2,
                Naziv = "Ridvanovi Recepti #2",
                Public = false
            });

            modelBuilder.Entity<Recepti>().HasData(new Recepti()
            {
                Id = 1,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Domaci Nanin Grah",
                Public = true,
                KategorijeId = 7
            });

            modelBuilder.Entity<Recepti>().HasData(new Recepti()
            {
                Id = 2,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Doner Kebab iz srca Turske",
                Public = true,
                KategorijeId = 4
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 1,
                ReceptId = 2,
                RedniBrojKoraka = 1,
                Deskripcija = "Priprema sosa za prekrivanje mesa."
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 2,
                ReceptId = 2,
                RedniBrojKoraka = 2,
                Deskripcija = "Przenje mesa."
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 3,
                ReceptId = 2,
                RedniBrojKoraka = 3,
                Deskripcija = "Jedenje."
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 4,
                ReceptId = 1,
                RedniBrojKoraka = 1,
                Deskripcija = "Ubrati grah."
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 5,
                ReceptId = 1,
                RedniBrojKoraka = 2,
                Deskripcija = "Skuhati."
            });

            modelBuilder.Entity<ReceptKoraci>().HasData(new ReceptKoraci()
            {
                Id = 6,
                ReceptId = 1,
                RedniBrojKoraka = 3,
                Deskripcija = "Dodati suhog mesa."
            });


            modelBuilder.Entity<ReceptSastojci>().HasData(new ReceptSastojci()
            {
                Id = 1,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<ReceptSastojci>().HasData(new ReceptSastojci()
            {
                Id = 2,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<ReceptSastojci>().HasData(new ReceptSastojci()
            {
                Id = 3,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                Id = 1,
                ReceptId = 2,
                InsertTime = System.DateTime.Now,
                KorisnikId = 1,
                Mark = RatingMark.FIVE_STAR,
                Comment = "Predobar doner."
            });

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Korisnici>(entity =>
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

            modelBuilder.Entity<Uloge>(entity =>
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
