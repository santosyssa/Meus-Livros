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
    public class AutorRepository : IAutorRepository
    {
        LivrosContext ctx = new LivrosContext();

        public List<Autor> Listar()
        {
            return ctx.Autores.Include(x => x.Livros).ToList();
        }

        public void Cadastrar(Autor autor)
        {
            ctx.Autores.Add(autor);
            ctx.SaveChanges();
        }

        internal static void Cadastrar(object autor)
        {
            throw new NotImplementedException();
        }
    }
}
