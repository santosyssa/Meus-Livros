using Meus_Livros_WebApplication.Domains;
using Meus_Livros_WebApplication.Interfaces;
using Meus_Livros_WebApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_Livros_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private ILivroRepository LivroRepository { get; set; }

        public LivroController()
        {
            LivroRepository = new LivroRepository();
        }

        [HttpGet]
        public IActionResult ListarLivro()
        {
            return Ok(LivroRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                LivroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("nome/{nome}")]
        public IActionResult FiltrarPorNome([FromRoute]string nome)
        {
            try
            {
                return Ok(LivroRepository.FiltrarPorNome(nome));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("data/{data}")]
        public IActionResult FiltrarPorData([FromRoute]DateTime data)
        {
            try
            {
                return Ok(LivroRepository.FiltrarPorData(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("data/{dataInicio}/{dataFim}")]
        public IActionResult FiltrarPorData([FromRoute] DateTime dataInicio, [FromRoute]DateTime dataFim)
        {
            try
            {
                return Ok(LivroRepository.FiltrarPorData(dataInicio, dataFim));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("editora/{editora}")]
        public IActionResult ListarLivroEditoraFavorita([FromRoute] int editora)
        {
            try
            {
                return Ok(LivroRepository.ListarLivroEditoraFavorita(editora));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
