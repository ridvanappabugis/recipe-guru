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

        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<Uloga> Uloge { get; set; }
        public virtual DbSet<ImageResource> ImageResources { get; set; }
        public virtual DbSet<Kategorija> Kategorije { get; set; }
        public virtual DbSet<KnjigaRecepata> KnjigeRecepata { get; set; }
        public virtual DbSet<Recept> Recepti { get; set; }
        public virtual DbSet<ReceptKorak> ReceptKoraci { get; set; }
        public virtual DbSet<ReceptSastojak> ReceptSastojci { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

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

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                Id = 3,
                Naziv = Role.VISITOR
            });

            // admin
            Korisnik u1 = new Korisnik
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
            modelBuilder.Entity<Korisnik>().HasData(u1);

            // client user
            Korisnik u2 = new Korisnik
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
            modelBuilder.Entity<Korisnik>().HasData(u2);

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
                modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
                {
                    Id = i++,
                    Naziv = kategorija
                });
            }

            modelBuilder.Entity<KnjigaRecepata>().HasData(new KnjigaRecepata()
            {
                Id = 1,
                KorisnikId = 2,
                Naziv = "Ridvanovi Recepti",
                Deskripcija = "Moji dobri recepti",
                Public = true
            });

            modelBuilder.Entity<KnjigaRecepata>().HasData(new KnjigaRecepata()
            {
                Id = 2,
                KorisnikId = 2,
                Naziv = "Ridvanovi Recepti #2",
                Deskripcija = "Bolji recepti",
                Public = false
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 1,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Domaci Nanin Grah",
                Public = true,
                KategorijaId = 7
            });

            modelBuilder.Entity<Recept>().HasData(new Recept()
            {
                Id = 2,
                KnjigaRecepataId = 1,
                BrojPregleda = 0,
                DuzinaPripreme = 30,
                Naziv = "Doner Kebab iz srca Turske",
                Public = true,
                KategorijaId = 4
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 1,
                ReceptId = 2,
                RedniBrojKoraka = 1,
                Deskripcija = "Priprema sosa za prekrivanje mesa."
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 2,
                ReceptId = 2,
                RedniBrojKoraka = 2,
                Deskripcija = "Przenje mesa."
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 3,
                ReceptId = 2,
                RedniBrojKoraka = 3,
                Deskripcija = "Jedenje."
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 4,
                ReceptId = 1,
                RedniBrojKoraka = 1,
                Deskripcija = "Ubrati grah."
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 5,
                ReceptId = 1,
                RedniBrojKoraka = 2,
                Deskripcija = "Skuhati."
            });

            modelBuilder.Entity<ReceptKorak>().HasData(new ReceptKorak()
            {
                Id = 6,
                ReceptId = 1,
                RedniBrojKoraka = 3,
                Deskripcija = "Dodati suhog mesa."
            });


            modelBuilder.Entity<ReceptSastojak>().HasData(new ReceptSastojak()
            {
                Id = 1,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<ReceptSastojak>().HasData(new ReceptSastojak()
            {
                Id = 2,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<ReceptSastojak>().HasData(new ReceptSastojak()
            {
                Id = 3,
                ReceptId = 2,
                Kolicina = "1 kilgoram",
                Naziv = "Telece meso."
            });

            modelBuilder.Entity<Rating>().HasData(new Rating()
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
