using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace summerschool.DMO;

public partial class SummerSchoolContext : DbContext
{
    public SummerSchoolContext()
    {
    }

    public SummerSchoolContext(DbContextOptions<SummerSchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FormApply> FormApplies { get; set; }

    public virtual DbSet<TableLesson> TableLessons { get; set; }

    public virtual DbSet<TableStudent> TableStudents { get; set; }

    public virtual DbSet<TableTeacher> TableTeachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormApply>(entity =>
        {
            entity.HasKey(e => e.Formid);

            entity.ToTable("FormApply");

            entity.Property(e => e.Formid).HasColumnName("FORMID");
            entity.Property(e => e.Lsid).HasColumnName("LSID");
            entity.Property(e => e.Stid).HasColumnName("STID");

            entity.HasOne(d => d.Ls).WithMany(p => p.FormApplies)
                .HasForeignKey(d => d.Lsid)
                .HasConstraintName("FK_FormApply_TableLessons");

            entity.HasOne(d => d.St).WithMany(p => p.FormApplies)
                .HasForeignKey(d => d.Stid)
                .HasConstraintName("FK_FormApply_TableStudent");
        });

        modelBuilder.Entity<TableLesson>(entity =>
        {
            entity.HasKey(e => e.Lsid);

            entity.Property(e => e.Lsid).HasColumnName("LSID");
            entity.Property(e => e.Lsmaxquota).HasColumnName("LSMAXQUOTA");
            entity.Property(e => e.Lsminquota).HasColumnName("LSMINQUOTA");
            entity.Property(e => e.Lsname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LSNAME");
        });

        modelBuilder.Entity<TableStudent>(entity =>
        {
            entity.HasKey(e => e.Stid);

            entity.ToTable("TableStudent");

            entity.Property(e => e.Stid).HasColumnName("STID");
            entity.Property(e => e.Stbalance)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("STBALANCE");
            entity.Property(e => e.Stlastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STLASTNAME");
            entity.Property(e => e.Stmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STMAIL");
            entity.Property(e => e.Stname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STNAME");
            entity.Property(e => e.Stnumber)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("STNUMBER");
            entity.Property(e => e.Stpassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STPASSWORD");
        });

        modelBuilder.Entity<TableTeacher>(entity =>
        {
            entity.HasKey(e => e.Tchrid);

            entity.ToTable("TableTeacher");

            entity.Property(e => e.Tchrid).HasColumnName("TCHRID");
            entity.Property(e => e.Tchnamelastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TCHNAMELASTNAME");
            entity.Property(e => e.Tchrbranch).HasColumnName("TCHRBRANCH");

            entity.HasOne(d => d.TchrbranchNavigation).WithMany(p => p.TableTeachers)
                .HasForeignKey(d => d.Tchrbranch)
                .HasConstraintName("FK_TableTeacher_TableLessons");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
