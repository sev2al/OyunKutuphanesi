using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _231103083_sevvalkaragol.DAL;

public partial class AkkarlojistikdemoContext : DbContext
{
    public AkkarlojistikdemoContext()
    {
    }

    public AkkarlojistikdemoContext(DbContextOptions<AkkarlojistikdemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hizmetler> Hizmetlers { get; set; }

    public virtual DbSet<Iletisim> Iletisims { get; set; }

    public virtual DbSet<Tesisler> Tesislers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-IM6U7KIP;Initial Catalog=akkarlojistikdemo;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hizmetler>(entity =>
        {
            entity.ToTable("Hizmetler");

            entity.Property(e => e.Baslik).HasMaxLength(500);
            entity.Property(e => e.Fotograf).HasMaxLength(500);
        });

        modelBuilder.Entity<Iletisim>(entity =>
        {
            entity.ToTable("Iletisim");

            entity.Property(e => e.Adres).HasMaxLength(500);
            entity.Property(e => e.Eposta).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<Tesisler>(entity =>
        {
            entity.ToTable("Tesisler");

            entity.Property(e => e.Aciklama).HasMaxLength(1000);
            entity.Property(e => e.Baslik).HasMaxLength(500);
            entity.Property(e => e.Fotograf).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
