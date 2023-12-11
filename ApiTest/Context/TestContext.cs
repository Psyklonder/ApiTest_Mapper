using System;
using System.Collections.Generic;
using ApiTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Context;

public partial class TestContext : DbContext
{
    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Identificacion)
                .IsUnicode(false)
                .HasComputedColumnSql("(([dbo].[ObtenerTipoPorID]([TipoIdentificacionId])+' ')+[NumeroIdentificacion])", false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(101)
                .IsUnicode(false)
                .HasComputedColumnSql("(([Nombres]+' ')+[Apellidos])", false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoIdentificacion).WithMany(p => p.Persona)
                .HasForeignKey(d => d.TipoIdentificacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_TipoIdentificacion");
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Persona).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
