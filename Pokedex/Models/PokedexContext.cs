using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pokedex.Models;

public partial class PokedexContext : DbContext
{
    public PokedexContext()
    {
    }

    public PokedexContext(DbContextOptions<PokedexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entrenadores> Entrenadores { get; set; }

    public virtual DbSet<Pokemones> Pokemones { get; set; }

    public virtual DbSet<Tipos> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=root;user=root;database=Pokedex", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Entrenadores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("entrenadores");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<Pokemones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pokemones");

            entity.HasIndex(e => e.EntrenadorId, "fk_Pokemones_Entrenadores");

            entity.HasIndex(e => e.TipoId, "fk_Pokemones_Tipos");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Habilidad).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Entrenador).WithMany(p => p.Pokemones)
                .HasForeignKey(d => d.EntrenadorId)
                .HasConstraintName("fk_Pokemones_Entrenadores");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Pokemones)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("fk_Pokemones_Tipos");
        });

        modelBuilder.Entity<Tipos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipos");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
