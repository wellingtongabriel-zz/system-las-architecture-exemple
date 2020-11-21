using Sistema.Las.Domain.Genericos.Entidades;

namespace Sistema.Las.Domain.Autenticacao.Comandos
{
    public class AutenticacaoCommandBase : CommandBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
