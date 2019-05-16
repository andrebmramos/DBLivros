using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBLivros
{
    public class LivroContext : DbContext
    {
        // OBJETOS DAS TABELAS
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroCategoria> LivroCategorias { get; set; }

        // ...
        public LivroContext(DbContextOptions<LivroContext> options) :
            base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.HasDefaultSchema("lvr");

            modelBuilder.Entity<Autor>()
                .HasMany(pessoa => pessoa.Livros)
                .WithOne(livro => livro.Autor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Capitulo>()
                .HasOne(capitulo => capitulo.Livro)
                .WithMany(livro => livro.Capitulos);

            // MUITOS PARA MUITOS
            // ...chave dupla
            modelBuilder.Entity<LivroCategoria>()
                .HasKey(lct => new { lct.LivroId, lct.CategoriaId });
            // ...vínculo dos livros
            modelBuilder.Entity<LivroCategoria>()
                .HasOne(lct => lct.Livro)
                .WithMany(livro => livro.LivroCategorias)
                .HasForeignKey(lct => lct.LivroId)
                .OnDelete(DeleteBehavior.Restrict);
            // ...vínculo das categorias
            modelBuilder.Entity<LivroCategoria>()
                .HasOne(lct => lct.Categoria)
                .WithMany(cat => cat.LivroCategorias)
                .HasForeignKey(lct => lct.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);            

            // Seed dados de exemplo          
            modelBuilder.Entity<Autor>().HasData(GetAutores());
            modelBuilder.Entity<Categoria>().HasData(GetCategorias());
            modelBuilder.Entity<Livro>().HasData(GetLivros());
            modelBuilder.Entity<Capitulo>().HasData(GetCapitulos());
            modelBuilder.Entity<LivroCategoria>().HasData(GetLivroCategorias());

        }

        #region DadosDeExemplo
        public static Autor[] GetAutores()
        {
            return new Autor[]
            {
                new Autor { AutorId = -1, Nome = "Andre" },
                new Autor { AutorId = -2, Nome = "Carlos" },
                new Autor { AutorId = -3, Nome = "Tassia" }
            };
        }

        public static Categoria[] GetCategorias()
        {
            return new Categoria[]
            {
                new Categoria { CategoriaId = -1,  Descricao = "Ficção" },
                new Categoria { CategoriaId = -2,  Descricao = "Infantil" },
                new Categoria { CategoriaId = -3,  Descricao = "Romance" },
                new Categoria { CategoriaId = -4,  Descricao = "Mais vendidos" }
            };
        }

        public static Capitulo[] GetCapitulos()
        {
            return new Capitulo[]
            {
                new Capitulo { CapituloId = -1,  Conteudo = "Primeiro capitulo de ficção",  LivroId = -1 },
                new Capitulo { CapituloId = -2,  Conteudo = "Segundo capitulo de ficção",  LivroId = -1 },
                new Capitulo { CapituloId = -3,  Conteudo = "Terceiro capitulo de ficção",  LivroId = -1 },
                new Capitulo { CapituloId = -4,  Conteudo = "Primeiro capitulo de infantil",  LivroId = -2 },
                new Capitulo { CapituloId = -5,  Conteudo = "Segundo capitulo de infantil",  LivroId = -2 },
                new Capitulo { CapituloId = -6,  Conteudo = "Primeiro capitulo de romance",  LivroId = -3 },
                new Capitulo { CapituloId = -7,  Conteudo = "Segundo capitulo de romance",  LivroId = -3 }
            };
        }

        public static Livro[] GetLivros()
        {
            return new Livro[]
            {
                new Livro { LivroId = -1,  Nome = "Livro de Ficção", AutorId = -1 },
                new Livro { LivroId = -2,  Nome = "Livro Infantil", AutorId = -2  },
                new Livro { LivroId = -3,  Nome = "Livro de Romance", AutorId = -3  }
            };
        }

        public static LivroCategoria[] GetLivroCategorias()
        {
            return new LivroCategoria[]
            {
                new LivroCategoria { LivroId = -1, CategoriaId = -1 },
                new LivroCategoria { LivroId = -1, CategoriaId = -4 },
                new LivroCategoria { LivroId = -2, CategoriaId = -2 },
                new LivroCategoria { LivroId = -2, CategoriaId = -4 },
                new LivroCategoria { LivroId = -3, CategoriaId = -3 }
            };
        }
        #endregion

    }

    // CLASSE AUXILIAR
    public class PaymentContextFactory : IDesignTimeDbContextFactory<LivroContext>
    {

        public LivroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LivroContext>();
            optionsBuilder.UseSqlServer(Program.ConnectionString);
            return new LivroContext(optionsBuilder.Options);
        }
    }


}
