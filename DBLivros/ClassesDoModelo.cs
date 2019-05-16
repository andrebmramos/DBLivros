using System;
using System.Collections.Generic;
using System.Text;

namespace DBLivros
{

    public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public List<Livro> Livros { get; set; }
    }



    public class Capitulo
    {
        public int CapituloId { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public string Conteudo { get; set; }
    }


    public class Livro
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public List<Capitulo> Capitulos { get; set; } = new List<Capitulo>();
        // public List<Categoria> Categorias { get; set; } = new List<Categoria>(); // (***)
        public List<LivroCategoria> LivroCategorias { get; set; } = new List<LivroCategoria>();
    }


    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        // public List<Livro> Livros { get; set; } = new List<Livro>(); // (***)
        public List<LivroCategoria> LivroCategorias { get; set; } = new List<LivroCategoria>();
    }


    // (***) O Entiry Framework Core 2.2 ainda não implementou forma de fazer relação
    // muitos para muitos (HasMany + WithMany), de modo que é preciso fazer explicitamente
    // a tabela de relacionamentos. Dessa forma, ao invés de Livro ter uma List<Categoria>
    // e Categoria ter uma List<Livro>, cada um tem uma List<LivroCategoria> e, por meio 
    // dessa, posso fazer minhas queries das categorias de ada livro, ou dos livros de
    // cada categoria.
    public class LivroCategoria
    {
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }

}
