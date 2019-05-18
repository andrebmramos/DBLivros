using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBLivros.Scaffold
{
    public partial class ScaffoldDbContext : DbContext
    {
        public ScaffoldDbContext()
        {
        }

        public ScaffoldDbContext(DbContextOptions<ScaffoldDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Capitulos> Capitulos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<LivroCategorias> LivroCategorias { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=LivrosDB;User Id=sa; Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Autores>(entity =>
            {
                entity.HasKey(e => e.AutorId);
            });

            modelBuilder.Entity<Capitulos>(entity =>
            {
                entity.HasKey(e => e.CapituloId);

                entity.HasIndex(e => e.LivroId);

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Capitulos)
                    .HasForeignKey(d => d.LivroId);
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId);
            });

            modelBuilder.Entity<LivroCategorias>(entity =>
            {
                entity.HasKey(e => new { e.LivroId, e.CategoriaId });

                entity.HasIndex(e => e.CategoriaId);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.LivroCategorias)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.LivroCategorias)
                    .HasForeignKey(d => d.LivroId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.HasKey(e => e.LivroId);

                entity.HasIndex(e => e.AutorId);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
