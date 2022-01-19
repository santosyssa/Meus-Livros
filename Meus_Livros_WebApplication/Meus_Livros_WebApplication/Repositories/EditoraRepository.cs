using Meus_Livros_WebApplication.Contexts;
using Meus_Livros_WebApplication.Domains;
using Meus_Livros_WebApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Livros_WebApplication.Repositories
{
    public class EditoraRepository : IEditoraRepository
    {
        LivrosContext ctx = new LivrosContext();

        public List<Editora> Listar()
        {
            return ctx.Editoras.ToList();
        }

        public List<Favorito> ListarEditoraFavorita()
        {
            return ctx.Favoritos.Include(x => x.IdEditoraNavigation).ToList();

        }

        public void Cadastrar(Editora editora)
        {
            ctx.Editoras.Add(editora);
            ctx.SaveChanges();
        }

        public List<Favorito> ListarEditoraFavorita(int id)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
