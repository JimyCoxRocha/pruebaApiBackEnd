using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace storeAPI.Models
{
    public partial class storeapiContext : DbContext
    {
        public storeapiContext()
        {
        }

        public storeapiContext(DbContextOptions<storeapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K77OCLB;Database=storeapi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Plan");

                entity.Property(e => e.Cant)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cant");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
