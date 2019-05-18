using System;
using System.Collections.Generic;

namespace DBLivros.Scaffold
{
    public partial class LivroCategorias
    {
        public int LivroId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual Livros Livro { get; set; }
    }
}
