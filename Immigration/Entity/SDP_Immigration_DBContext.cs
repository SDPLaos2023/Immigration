using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Immigration.Entity
{
    public partial class SDP_Immigration_DBContext : DbContext
    {
        public SDP_Immigration_DBContext()
        {
        }

        public SDP_Immigration_DBContext(DbContextOptions<SDP_Immigration_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlackListRegister> BlackListRegister { get; set; } = null!;
        public virtual DbSet<BorderPassRegister> BorderPassRegister { get; set; } = null!;
        public virtual DbSet<PassportRegister> PassportRegister { get; set; } = null!;
        public virtual DbSet<TemporaryBorderPassRegister> TemporaryBorderPassRegister { get; set; } = null!;
        public virtual DbSet<TruckMasterData> TruckMasterData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=SDP_Immigration_DB;user id=sa;pwd=sugarps2;Trusted_Connection=False;");
                string Connection = GetConfiguration();
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        public string GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            var Connect = configuration.GetSection("ConnectionStrings").GetSection("DBContext").Value;
            return Connect;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CI_AS");

            modelBuilder.Entity<BlackListRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BLACK_LIST_REGISTER");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(1000)
                    .HasColumnName("Birth_Country");

                entity.Property(e => e.BirthOfDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_of_date");

                entity.Property(e => e.Country).HasMaxLength(1000);

                entity.Property(e => e.DocumentNo).HasColumnName("Document_No");

                entity.Property(e => e.GivenName)
                    .HasMaxLength(1000)
                    .HasColumnName("Given_name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(1000);
            });

            modelBuilder.Entity<BorderPassRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BORDER_PASS_REGISTER");

                entity.Property(e => e.BirthOfDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_of_date");

                entity.Property(e => e.Country).HasMaxLength(1000);

                entity.Property(e => e.District).HasMaxLength(1000);

                entity.Property(e => e.DocumentNo).HasColumnName("Document_No");

                entity.Property(e => e.GivenName)
                    .HasMaxLength(1000)
                    .HasColumnName("Given_name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Occupation).HasMaxLength(1000);

                entity.Property(e => e.Province).HasMaxLength(1000);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(1000);

                entity.Property(e => e.Village).HasMaxLength(1000);
            });

            modelBuilder.Entity<PassportRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PASSPORT_REGISTER");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(1000)
                    .HasColumnName("Birth_Country");

                entity.Property(e => e.BirthOfDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_of_date");

                entity.Property(e => e.Country).HasMaxLength(1000);

                entity.Property(e => e.DocumentNo).HasColumnName("Document_No");

                entity.Property(e => e.GivenName)
                    .HasMaxLength(1000)
                    .HasColumnName("Given_name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(1000);
            });

            modelBuilder.Entity<TemporaryBorderPassRegister>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEMPORARY_BORDER_PASS_REGISTER");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(1000)
                    .HasColumnName("Birth_Country");

                entity.Property(e => e.BirthOfDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_of_date");

                entity.Property(e => e.Country).HasMaxLength(1000);

                entity.Property(e => e.DocumentNo).HasColumnName("Document_No");

                entity.Property(e => e.GivenName)
                    .HasMaxLength(1000)
                    .HasColumnName("Given_name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(1000);
            });

            modelBuilder.Entity<TruckMasterData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRUCK_MASTER_DATA");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(1000)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.TruckLicencePlateNo)
                    .HasMaxLength(8)
                    .HasColumnName("TRUCK_LICENCE_PLATE_NO");

                entity.Property(e => e.TruckType)
                    .HasMaxLength(10)
                    .HasColumnName("TRUCK_TYPE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
