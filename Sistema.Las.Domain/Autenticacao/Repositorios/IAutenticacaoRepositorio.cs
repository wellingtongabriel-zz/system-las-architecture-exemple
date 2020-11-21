using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Sistema.Las.Domain.Autenticacao.Repositorios
{
    public interface IAutenticacaoRepositorio
    {
        Task<SignInResult> Login(string email, string password);
        Task<IdentityResult> RegistrarAsync(IdentityUser identityUser, string password);
    }
}
