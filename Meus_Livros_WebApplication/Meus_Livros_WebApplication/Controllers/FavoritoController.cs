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
    public class FavoritoController : ControllerBase
    {
        private IFavoritoRepository FavoritoRepository { get; set; }

        public FavoritoController()
        {
            FavoritoRepository = new FavoritoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FavoritoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Favorito favorito)
        {
            try
            {
                FavoritoRepository.Cadastrar(favorito);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

    }
}
