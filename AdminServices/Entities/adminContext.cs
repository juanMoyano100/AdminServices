using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminServices.Entities
{
    public partial class adminContext : DbContext
    {
        public adminContext()
        {
        }

        public adminContext(DbContextOptions<adminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Informacionpersonal> Informacionpersonal { get; set; }
        public virtual DbSet<Tiposangre> Tiposangre { get; set; }
        public virtual DbSet<Tipousuario> Tipousuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=proyectohospitalariodiagnosticos.mysql.database.azure.com;port=3306;user=diagnosticoAdmin@proyectohospitalariodiagnosticos;password=Diagnosticos123456;database=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Informacionpersonal>(entity =>
            {
                entity.HasKey(e => e.IdInformacionPersonal)
                    .HasName("PRIMARY");

                entity.ToTable("informacionpersonal");

                entity.HasIndex(e => e.IdTipoSangre)
                    .HasName("fk_InformacionPersonal_TipoSangre1_idx");

                entity.Property(e => e.IdInformacionPersonal).HasColumnType("int(11)");

                entity.Property(e => e.CiudadResidencia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionResidencia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EstaEmbarazada)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoSangre).HasColumnType("int(11)");

                entity.Property(e => e.Nacionalidad)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NombresContacto)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoSangreNavigation)
                    .WithMany(p => p.Informacionpersonal)
                    .HasForeignKey(d => d.IdTipoSangre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InformacionPersonal_TipoSangre1");
            });

            modelBuilder.Entity<Tiposangre>(entity =>
            {
                entity.HasKey(e => e.IdTipoSangre)
                    .HasName("PRIMARY");

                entity.ToTable("tiposangre");

                entity.Property(e => e.IdTipoSangre).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("tipousuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.IdInformacionPersonal)
                    .HasName("fk_Usuario_InformacionPersonal1_idx");

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("fk_Usuario_TipoUsuario_idx");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdInformacionPersonal).HasColumnType("int(11)");

                entity.Property(e => e.IdTipoUsuario).HasColumnType("int(11)");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInformacionPersonalNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdInformacionPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_InformacionPersonal1");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_TipoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
