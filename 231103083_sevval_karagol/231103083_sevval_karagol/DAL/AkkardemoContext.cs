using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _231103083_sevval_karagol.DAL;

public partial class AkkardemoContext : DbContext
{
    public AkkardemoContext()
    {
    }

    public AkkardemoContext(DbContextOptions<AkkardemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Belgeler> Belgelers { get; set; }

    public virtual DbSet<Duyurular> Duyurulars { get; set; }

    public virtual DbSet<Faaliyetlerimiz> Faaliyetlerimizs { get; set; }

    public virtual DbSet<Hakkimizdum> Hakkimizda { get; set; }

    public virtual DbSet<Hizmetler> Hizmetlers { get; set; }

    public virtual DbSet<Iletisim> Iletisims { get; set; }

    public virtual DbSet<Iletisimform> Iletisimforms { get; set; }

    public virtual DbSet<Kurumsal> Kurumsals { get; set; }

    public virtual DbSet<MisyonVizyon> MisyonVizyons { get; set; }

    public virtual DbSet<Tesisler> Tesislers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-IM6U7KIP;Initial Catalog=akkardemo;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Belgeler>(entity =>
        {
            entity.ToTable("Belgeler");

            entity.Property(e => e.Belgeler1)
                .HasMaxLength(500)
                .HasColumnName("Belgeler");
            entity.Property(e => e.Fotograf).HasMaxLength(500);
        });

        modelBuilder.Entity<Duyurular>(entity =>
        {
            entity.ToTable("Duyurular");

            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.Baslik).HasMaxLength(500);
            entity.Property(e => e.Tarih).HasColumnType("datetime");
        });

        modelBuilder.Entity<Faaliyetlerimiz>(entity =>
        {
            entity.ToTable("Faaliyetlerimiz");

            entity.Property(e => e.Aciklama).HasMaxLength(4000);
            entity.Property(e => e.Baslik).HasMaxLength(200);
            entity.Property(e => e.Fotograf).HasMaxLength(100);
            entity.Property(e => e.FotografBaslik).HasMaxLength(100);
        });

        modelBuilder.Entity<Hakkimizdum>(entity =>
        {
            entity.Property(e => e.Aciklama).HasMaxLength(4000);
            entity.Property(e => e.Baslik).HasMaxLength(500);
            entity.Property(e => e.Fotograf).HasMaxLength(500);
        });

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
            entity.Property(e => e.Eposta).HasMaxLength(500);
            entity.Property(e => e.Fax).HasMaxLength(500);
            entity.Property(e => e.Telefon).HasMaxLength(500);
        });

        modelBuilder.Entity<Iletisimform>(entity =>
        {
            entity.ToTable("Iletisimform");

            entity.Property(e => e.Ad).HasMaxLength(500);
            entity.Property(e => e.Mail).HasMaxLength(500);
            entity.Property(e => e.Telefon).HasMaxLength(500);
        });

        modelBuilder.Entity<Kurumsal>(entity =>
        {
            entity.ToTable("Kurumsal");

            entity.Property(e => e.Aciklama).HasMaxLength(4000);
            entity.Property(e => e.Baslik).HasMaxLength(100);
            entity.Property(e => e.Fotograf).HasMaxLength(100);
        });

        modelBuilder.Entity<MisyonVizyon>(entity =>
        {
            entity.ToTable("MisyonVizyon");
        });

        modelBuilder.Entity<Tesisler>(entity =>
        {
            entity.ToTable("Tesisler");

            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.Baslik).HasMaxLength(500);
            entity.Property(e => e.Fotograf).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
