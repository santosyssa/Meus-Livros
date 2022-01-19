using Meus_Livros_WebApplication.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Livros_WebApplication.Interfaces
{
    interface IGeneroRepository
    {
        List<Genero> Listar();

        void Cadastrar(Genero genero);
    }
}
