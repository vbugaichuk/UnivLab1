using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBIT
{
    public partial class DBITCompanyContext : DbContext
    {
        public DBITCompanyContext()
        {
        }

        public DBITCompanyContext(DbContextOptions<DBITCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EmpSub> EmpSubs { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<ItCompany> ItCompanies { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<EmpPosition> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G05H9NK\\SQLEXPRESS; Database=DBITCompany; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmpSub>(entity =>
            {
                entity.ToTable("Emp_Subs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployerId).HasColumnName("Employer_id");

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.SubdivisionId).HasColumnName("Subdivision_id");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Employers");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Positions");

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.SubdivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Subdivisions");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItCompany>(entity =>
            {
                entity.ToTable("IT_Companies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.ItCompanyId).HasColumnName("IT_Company_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offices_Cities");

                entity.HasOne(d => d.ItCompany)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.ItCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offices_IT_Companies");
            });

            modelBuilder.Entity<EmpPosition>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItCompanyId).HasColumnName("IT_Company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ItCompany)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ItCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_IT_Companies");
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeId).HasColumnName("Office_id");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Subdivisions)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdivisions_Offices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
