using Meus_Livros_WebApplication.Contexts;
using Meus_Livros_WebApplication.Domains;
using Meus_Livros_WebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Livros_WebApplication.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        LivrosContext ctx = new LivrosContext();

        public List<Genero> Listar()
        {
            return ctx.Generos.OrderBy(x => x.IdGenero).ToList();
        }

        public void Cadastrar(Genero genero)
        {
            ctx.Generos.Add(genero);
            ctx.SaveChanges();
        }
    }
}
