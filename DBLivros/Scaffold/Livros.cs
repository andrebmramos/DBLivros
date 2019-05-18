using System;
using System.Collections.Generic;

namespace DBLivros.Scaffold
{
    public partial class Livros
    {
        public Livros()
        {
            Capitulos = new HashSet<Capitulos>();
            LivroCategorias = new HashSet<LivroCategorias>();
        }

        public int LivroId { get; set; }
        public string Nome { get; set; }
        public int AutorId { get; set; }

        public virtual Autores Autor { get; set; }
        public virtual ICollection<Capitulos> Capitulos { get; set; }
        public virtual ICollection<LivroCategorias> LivroCategorias { get; set; }
    }
}
