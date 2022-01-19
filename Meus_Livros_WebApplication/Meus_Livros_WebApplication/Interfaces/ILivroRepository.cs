using Meus_Livros_WebApplication.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Livros_WebApplication.Interfaces
{
    interface ILivroRepository
    {
        List<Livro> Listar();

        List<Livro> FiltrarPorData(DateTime data);

        List<Livro> FiltrarPorData(DateTime dataInicio, DateTime dataFim);

        List<Livro> FiltrarPorNome(string nome);

        List<Livro> ListarLivroEditoraFavorita(int nome);

        void Cadastrar(Livro livro);
    }
}
