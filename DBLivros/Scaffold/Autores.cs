using System;
using System.Collections.Generic;

namespace DBLivros.Scaffold
{
    public partial class Autores
    {
        public Autores()
        {
            Livros = new HashSet<Livros>();
        }

        public int AutorId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livros> Livros { get; set; }
    }
}
