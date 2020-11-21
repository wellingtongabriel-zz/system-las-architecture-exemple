namespace Sistema.Las.Domain.Autenticacao.Comandos
{
    public class RegistrarUsuarioCommand : AutenticacaoCommandBase
    {
        public string Nome { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
