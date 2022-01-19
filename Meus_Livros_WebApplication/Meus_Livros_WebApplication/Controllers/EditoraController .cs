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
    public class EditoraController : ControllerBase
    {
        private IEditoraRepository EditoraRepository { get; set; }

        public EditoraController()
        {
            EditoraRepository = new EditoraRepository();
        }

        [HttpGet]
        public IActionResult ListarEditora()
        {
            return Ok(EditoraRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Editora editora)
        {
            try
            {
                EditoraRepository.Cadastrar(editora);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
