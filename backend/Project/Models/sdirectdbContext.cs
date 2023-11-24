using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task29August.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartbookDetail> CartbookDetails { get; set; } = null!;
        public virtual DbSet<CustomerStripe> CustomerStripes { get; set; } = null!;
        public virtual DbSet<ImageUpLoadEmployee> ImageUpLoadEmployees { get; set; } = null!;
        public virtual DbSet<LocationDetail> LocationDetails { get; set; } = null!;
        public virtual DbSet<Loginvalidate2> Loginvalidate2s { get; set; } = null!;
        public virtual DbSet<PatientCount> PatientCounts { get; set; } = null!;
        public virtual DbSet<PatientCount1> PatientCounts1 { get; set; } = null!;
        public virtual DbSet<PatientInformation> PatientInformations { get; set; } = null!;
        public virtual DbSet<PatientTable> PatientTables { get; set; } = null!;
        public virtual DbSet<PriceStripe> PriceStripes { get; set; } = null!;
        public virtual DbSet<ProductStripe> ProductStripes { get; set; } = null!;
        public virtual DbSet<RoleMasterTable21> RoleMasterTable21s { get; set; } = null!;
        public virtual DbSet<RolemappingPrashant4> RolemappingPrashant4s { get; set; } = null!;
        public virtual DbSet<Rolemaster21> Rolemaster21s { get; set; } = null!;
        public virtual DbSet<SessionStripe> SessionStripes { get; set; } = null!;
        public virtual DbSet<Transectionstripe> Transectionstripes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartbookDetail>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Cartbook__51BCD7B7D7DD57D3");

                entity.ToTable("CartbookDetail");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CustomerStripe>(entity =>
            {
                entity.ToTable("CustomerStripe");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.StripeCustomerId).HasMaxLength(255);
            });

            modelBuilder.Entity<ImageUpLoadEmployee>(entity =>
            {
                entity.ToTable("ImageUpLoadEmployee");

                entity.Property(e => e.ExcelLoc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FileLoc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ImgLoc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationDetail>(entity =>
            {
                entity.HasKey(e => e.Payid)
                    .HasName("PK__Location__082D8EEBF0CFC499");

                entity.ToTable("LocationDetail");

                entity.Property(e => e.Payid).HasColumnName("payid");

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsAllotted).HasColumnName("isAllotted");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.VideoLoc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("videoLoc");
            });

            modelBuilder.Entity<Loginvalidate2>(entity =>
            {
                entity.ToTable("loginvalidate2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IsAuthenticate).HasColumnName("isAuthenticate");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Otp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("otp");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientCount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("patient_count");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<PatientCount1>(entity =>
            {
                entity.HasKey(e => e.Dob)
                    .HasName("PK__PatientC__C0308D6E09FE8A75");

                entity.ToTable("PatientCount");

                entity.Property(e => e.Dob).HasColumnType("date");
            });

            modelBuilder.Entity<PatientInformation>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("PatientInformation");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientTable>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("PatientTable");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PriceStripe>(entity =>
            {
                entity.ToTable("PriceStripe");

                entity.Property(e => e.PriceId).HasMaxLength(255);

                entity.Property(e => e.ProductId).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductStripe>(entity =>
            {
                entity.ToTable("ProductStripe");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductId).HasMaxLength(255);

                entity.Property(e => e.ProductName).HasMaxLength(255);
            });

            modelBuilder.Entity<RoleMasterTable21>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleMasterTable21");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<RolemappingPrashant4>(entity =>
            {
                entity.HasKey(e => e.RoleMappingId)
                    .HasName("PK__Rolemapp__D8D4AF0624DDAC01");

                entity.ToTable("RolemappingPrashant4");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Rolemaster21>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Rolemaster21");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SessionStripe>(entity =>
            {
                entity.ToTable("SessionStripe");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.StripeCustomerId).HasMaxLength(255);

                entity.Property(e => e.StripeSessionId).HasMaxLength(255);
            });

            modelBuilder.Entity<Transectionstripe>(entity =>
            {
                entity.HasKey(e => e.TransectionId)
                    .HasName("PK__Transect__6FA9571230EECE90");

                entity.ToTable("Transectionstripe");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Mode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Paymentid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("paymentid");

                entity.Property(e => e.PriceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("priceId");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subscrptionid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("subscrptionid");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
