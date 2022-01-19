using System;
using System.Collections.Generic;

#nullable disable

namespace Meus_Livros_WebApplication.Domains
{
    public partial class Autor
    {
        public Autor()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
