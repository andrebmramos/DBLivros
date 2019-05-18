using System;
using System.Collections.Generic;

namespace DBLivros.Scaffold
{
    public partial class Categorias
    {
        public Categorias()
        {
            LivroCategorias = new HashSet<LivroCategorias>();
        }

        public int CategoriaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<LivroCategorias> LivroCategorias { get; set; }
    }
}
