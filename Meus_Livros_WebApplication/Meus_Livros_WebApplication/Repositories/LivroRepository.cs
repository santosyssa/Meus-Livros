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
    public class LivroRepository : ILivroRepository
    {
        LivrosContext ctx = new LivrosContext();
        public List<Livro> Listar()
        {
            return ctx.Livros.Include(x => x.IdAutorNavigation).Include(x => x.IdEditoraNavigation).
           Include(x => x.IdGeneroNavigation).ToList();
        }
        public void Cadastrar(Livro livro)
        {
            ctx.Livros.Add(livro);
            ctx.SaveChanges();
        }

        public List<Livro> FiltrarPorData(DateTime data)
        {
            return ctx.Livros.Where(x => x.DataPubli.Value == data).ToList();

        }


        public List<Livro> FiltrarPorData(DateTime dataInicio, DateTime dataFim)
        {
            return ctx.Livros.Where(x => x.DataPubli.Value >= dataInicio && x.DataPubli <= dataFim).ToList();

        }

        public List<Livro> FiltrarPorNome(string nome)
        {
            var autorId = ctx.Autores.FirstOrDefault(x => x.Nome == nome.ToLower())?.IdAutor;

            return ctx.Livros.Where(x => x.IdAutor == (autorId.HasValue ? autorId.Value : 0)).ToList();
        }


        public List<Livro> ListarLivroEditoraFavorita(int fav)
        {
            var editoraId = ctx.Favoritos.FirstOrDefault(x => x.IdEditora == fav)?.IdFav;

            return ctx.Livros.Where(x => x.IdEditora == (editoraId.HasValue ? editoraId.Value : 0)).ToList();
        }

    }
}
