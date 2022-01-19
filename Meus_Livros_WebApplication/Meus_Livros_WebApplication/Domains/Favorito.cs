using System;
using System.Collections.Generic;

#nullable disable

namespace Meus_Livros_WebApplication.Domains
{
    public partial class Favorito
    {
        public int IdFav { get; set; }
        public int? IdEditora { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
    }
}
