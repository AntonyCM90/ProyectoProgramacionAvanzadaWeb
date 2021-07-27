﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class ProyectoContext : DbContext
    {
        public ProyectoContext()
        {
        }

        public ProyectoContext(DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Guia> Guia { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ANTCASVM2\\SQLEXPRESS;Database=Proyecto;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId)
                    .HasColumnName("RolID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RolNombre)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Rol)
                    .WithMany()
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__RolID__2D27B809");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AspNetUse__UserI__2E1BDC42");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Guia>(entity =>
            {
                entity.Property(e => e.GuiaId).HasColumnName("GuiaID");

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaReserva).HasColumnType("date");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reserva__UserID__300424B4");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.GuiaId).HasColumnName("GuiaID");

                entity.Property(e => e.ImagenTour)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                //entity.Property(e => e.TourId)
                //    .HasColumnName("TourID")
                //    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Guia)
                    .WithMany()
                    .HasForeignKey(d => d.GuiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tour__GuiaID__30F848ED");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLogin__UserI__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
