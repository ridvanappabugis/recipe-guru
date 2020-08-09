using System;
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
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
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
                Naziv = "Administrator"
            });

            modelBuilder.Entity<Uloge>().HasData(new Uloge()
            {
                Id = 2,
                Naziv = "ClientUser"
            });

            // admin
            Korisnici u1 = new Korisnici
            {
                Id = 1,
                KorisniciUlogeId = 1,
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
                KorisniciUlogeId = 2,
                KorisnickoIme = "ClientUser",
                Telefon = "061234567",
                Ime = "Ridvan",
                Prezime = "Appa",
                Email = "ridvanclient@fit.ba",
            };

            u2.LozinkaSalt = PasswordUtil.GenerateSalt();
            u2.LozinkaHash = PasswordUtil.GenerateHash(u2.LozinkaSalt, "test");
            modelBuilder.Entity<Korisnici>().HasData(u2);

            // kategorije
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 1,
                Naziv = "Slatko"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 2,
                Naziv = "Slano"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 3,
                Naziv = "Salate"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 4,
                Naziv = "Pite"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 5,
                Naziv = "Pizze"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 6,
                Naziv = "Rostilj"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 7,
                Naziv = "Supe"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 8,
                Naziv = "Kolaci"
            });
            modelBuilder.Entity<Kategorije>().HasData(new Kategorije()
            {
                Id = 9,
                Naziv = "Vegan"
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

                entity.Property(e => e.Id).HasColumnName("KorisnikID");

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

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasKey(e => e.KorisnikUlogaId);

                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.KorisniciUloge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnici");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloge");
            });

           

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });

            InitialiseData(modelBuilder);
        }
    }
}
