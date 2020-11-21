using Microsoft.AspNetCore.Identity;
using Sistema.Las.Domain.Autenticacao.Repositorios;
using System.Threading.Tasks;

namespace Sistema.Las.Infra.Repositorios
{
    public class AutenticacaoRepositorio : IAutenticacaoRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutenticacaoRepositorio(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegistrarAsync(IdentityUser identityUser, string password) 
            => await _userManager.CreateAsync(identityUser, password);

        public async Task<SignInResult> Login(string email, string password) 
            => await _signInManager.PasswordSignInAsync(email, password, false, true);
    }
}
