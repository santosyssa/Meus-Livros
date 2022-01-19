using System;
using System.Collections.Generic;

#nullable disable

namespace Meus_Livros_WebApplication.Domains
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPubli { get; set; }
        public string Capa { get; set; }
        public int? IdGenero { get; set; }
        public int? IdAutor { get; set; }
        public int? IdEditora { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
    }
}
