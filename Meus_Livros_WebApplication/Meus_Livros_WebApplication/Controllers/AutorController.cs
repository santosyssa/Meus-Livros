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
    public class AutorController : ControllerBase
    {
        private IAutorRepository AutorRepository { get; set; }

        public AutorController()
        {
            AutorRepository = new AutorRepository();
        }

        [HttpGet]
        public IEnumerable<Autor> Listar()
        {
            return AutorRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(Autor autor)
        {
            try
            {
                AutorRepository.Cadastrar(autor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
