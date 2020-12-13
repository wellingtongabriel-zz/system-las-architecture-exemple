using Microsoft.AspNetCore.Mvc;
using Sistema.Las.Aplicacao.Autenticacao.Interfaces;
using Sistema.Las.Domain.Autenticacao.Comandos;
using System.Threading.Tasks;

namespace Sistema.Las.Api.Controllers
{
    [ApiController, ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController (
            IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Logar(LoginCommand logarCommand) 
            =>  Ok(await _autenticacaoService.LogarUsuario(logarCommand));

        [HttpPost("registrar")]
        public async Task<IActionResult> Post(RegistrarUsuarioCommand registrarUsuarioCommand) 
            => Ok(await _autenticacaoService.RegistarUsuario(registrarUsuarioCommand));
    }
}