using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class EmpfamilyContext : DbContext
{
    public EmpfamilyContext()
    {
    }

    public EmpfamilyContext(DbContextOptions<EmpfamilyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empfamily> Empfamilies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASTLPTWFH151\\SQLEXPRESS;Initial Catalog=Empfamily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empfamily>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empfamil__3213E83F61AE975B");

            entity.ToTable("Empfamily");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("AGE");
            entity.Property(e => e.DependencyAadhaarNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dependency_AadhaarNumber");
            entity.Property(e => e.DependencyDob)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dependency_DOB");
            entity.Property(e => e.DependencyOccupation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dependency_occupation");
            entity.Property(e => e.DependencyPanNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dependency_PAN_Number");
            entity.Property(e => e.DependencyType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dependency_TYPE");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_CODE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
