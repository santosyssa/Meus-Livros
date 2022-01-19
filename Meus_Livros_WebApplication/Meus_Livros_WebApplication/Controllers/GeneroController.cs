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
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository GeneroRepository { get; set; }

        public GeneroController()
        {
            GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult ListarGenero()
        {
            return Ok(GeneroRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Genero genero)
        {
            try
            {
                GeneroRepository.Cadastrar(genero);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
