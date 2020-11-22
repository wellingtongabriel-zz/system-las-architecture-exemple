using Sistema.Las.Domain.Genericos.Entidades;

namespace Sistema.Las.Domain.Autenticacao.Comandos
{
    public class AutenticacaoCommandBase : CommandHandlerBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
