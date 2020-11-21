using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Domain.Categorias.Comandos;
using System.Threading.Tasks;

namespace Sistema.Las.Api.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _categoriaService.BuscarTodos());

        [HttpPost]
        public async Task<IActionResult> Post(CriaCategoriaCommand criaCategoriaCommand) 
            => Ok(await _categoriaService.Adicionar(criaCategoriaCommand));
    }
}