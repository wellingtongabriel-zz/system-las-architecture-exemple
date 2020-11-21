using Sistema.Las.Domain.Entidades;

namespace Sistema.Las.Domain.Autenticacao.Entidades
{
    public class RegistrarUsuario : EntidadeBase
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }

        public RegistrarUsuario(string email, string password, string confirmPassword)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
