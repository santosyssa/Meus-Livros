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
    public class FavoritoRepository : IFavoritoRepository
    {
        LivrosContext ctx = new LivrosContext();

        public void Cadastrar(Favorito favorito)
        {
            ctx.Favoritos.Add(favorito);
            ctx.SaveChanges();
        }

        public List<Favorito> Listar()
        {
            return ctx.Favoritos.ToList();

        }
    }
}
