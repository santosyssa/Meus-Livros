using System;
using System.Collections.Generic;

#nullable disable

namespace Meus_Livros_WebApplication.Domains
{
    public partial class Editora
    {
        public Editora()
        {
            Favoritos = new HashSet<Favorito>();
            Livros = new HashSet<Livro>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Favorito> Favoritos { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
