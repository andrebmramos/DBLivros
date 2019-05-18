using System;
using System.Collections.Generic;

namespace DBLivros.Scaffold
{
    public partial class Capitulos
    {
        public int CapituloId { get; set; }
        public int LivroId { get; set; }
        public string Conteudo { get; set; }

        public virtual Livros Livro { get; set; }
    }
}
