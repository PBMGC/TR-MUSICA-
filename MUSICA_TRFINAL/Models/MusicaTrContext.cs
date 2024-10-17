﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MUSICA_TRFINAL.Models;

public partial class MusicaTrContext : DbContext
{
    public MusicaTrContext()
    {
    }

    public MusicaTrContext(DbContextOptions<MusicaTrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07051DEF7D");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE0458A70F2").IsUnique();

            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Vistos).HasDefaultValue(0);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}