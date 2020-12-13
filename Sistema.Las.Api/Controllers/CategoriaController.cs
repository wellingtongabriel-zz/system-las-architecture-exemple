using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Las.Aplicacao.Categorias.Interfaces;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Domain.Categorias.Comandos;
using System.Threading.Tasks;

namespace Sistema.Las.Api.Controllers
{
    [ApiController, Authorize, ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ICriaCategoriaCommandHandler _criaCategoriaCommandHandler;

        public CategoriaController(
            ICategoriaService categoriaService,
            ICriaCategoriaCommandHandler criaCategoriaCommandHandler)
        {
            _categoriaService = categoriaService;
            _criaCategoriaCommandHandler = criaCategoriaCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _categoriaService.BuscarTodos());

        [HttpPost]
        public async Task<IActionResult> Post(CriaCategoriaCommand criaCategoriaCommand) 
            => Ok(await _criaCategoriaCommandHandler.Executa(criaCategoriaCommand));
    }
}