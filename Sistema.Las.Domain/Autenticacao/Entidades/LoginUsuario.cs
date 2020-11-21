using Sistema.Las.Domain.Entidades;

namespace Sistema.Las.Domain.Autenticacao.Entidades
{
    public class LoginUsuario : EntidadeBase
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public LoginUsuario(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
