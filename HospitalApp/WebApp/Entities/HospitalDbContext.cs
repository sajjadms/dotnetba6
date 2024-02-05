using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Entities;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=HospitalDB;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.NationalityId).HasName("PK__National__F628E7A4B7F61E40");

            entity.ToTable("Nationality");

            entity.HasIndex(e => e.NationalityName, "UQ__National__9913200EBEF33FAE").IsUnique();

            entity.Property(e => e.NationalityId).HasColumnName("NationalityID");
            entity.Property(e => e.NationalityName).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3467586A31D");

            entity.HasIndex(e => e.AdharNo, "UQ__Patients__11C1127FCD4E32E3").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.AdharNo).HasMaxLength(20);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.MobileNo).HasMaxLength(100);
            entity.Property(e => e.NationalityId).HasColumnName("NationalityID");
            entity.Property(e => e.PatientName).HasMaxLength(100);

            entity.HasOne(d => d.Nationality).WithMany(p => p.Patients)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK__Patients__Nation__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
