using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiForUnitTest.Models;

public partial class ReactjsDbContext : DbContext
{
    public ReactjsDbContext()
    {
    }

    public ReactjsDbContext(DbContextOptions<ReactjsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Faruk-Abdullah;Database=ReactjsDb;User=sa;Password=123;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.DateOfJoin).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sales");

            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("customerName");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.ToTable("saleDetails");

            entity.Property(e => e.SaleDetailId).HasColumnName("saleDetailId");
            entity.Property(e => e.Particular)
                .HasMaxLength(250)
                .HasColumnName("particular");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
