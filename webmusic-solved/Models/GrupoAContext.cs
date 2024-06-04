﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webmusic_solved.Models;

public partial class GrupoAContext : DbContext
{
    public GrupoAContext()
    {
    }

    public GrupoAContext(DbContextOptions<GrupoAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albumes> Albumes { get; set; }

    public virtual DbSet<Artistas> Artistas { get; set; }

    public virtual DbSet<Canciones> Canciones { get; set; }

    public virtual DbSet<Festival> Festival { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=musicagrupos.database.windows.net;database=GrupoA;user=as;password=P0t@t0P0t@t0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Albumes>(entity =>
        {
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Artistas>(entity =>
        {
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Canciones>(entity =>
        {
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Album).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("FK_Canciones_Albumes");

            entity.HasOne(d => d.Artista).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.ArtistaId)
                .HasConstraintName("FK_Canciones_Artistas");
        });

        modelBuilder.Entity<Festival>(entity =>
        {
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Artista).WithMany(p => p.Festival)
                .HasForeignKey(d => d.ArtistaId)
                .HasConstraintName("FK_Festival_Artistas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
