using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sistema.Las.Api.Configuracoes.Indentity.Extensions;
using Sistema.Las.Aplicacao.Autenticacao.Contratos;
using Sistema.Las.Aplicacao.Autenticacao.Interfaces;
using Sistema.Las.Domain.Autenticacao.Comandos;
using Sistema.Las.Domain.Autenticacao.Repositorios;
using Sistema.Las.Domain.Genericos;
using Sistema.Las.Domain.Genericos.Entidades;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Autenticacao.Services
{
    public class AutenticacaoService : CommandHandlerBase, IAutenticacaoService
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        private readonly IdentitySettings _identitySettings;
        private readonly UserManager<IdentityUser> _userManager;

        public AutenticacaoService (
            IAutenticacaoRepositorio autenticacaoRepositorio,
            IOptions<IdentitySettings> identitySettings,
            UserManager<IdentityUser> userManager)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
            _identitySettings = identitySettings.Value;
            _userManager = userManager;
        }

        public async Task<Result> LogarUsuario(LoginCommand logarCommand)
        {
            await _autenticacaoRepositorio.Login(logarCommand.Email, logarCommand.Password);
            return Return(await GerarJwt(logarCommand.Email));
        }

        public async Task<Result> RegistarUsuario(RegistrarUsuarioCommand registrarUsuarioCommand)
        {
            var usuario = new IdentityUser
            {
                UserName = registrarUsuarioCommand.Nome,
                Email = registrarUsuarioCommand.Email,
                EmailConfirmed = true
            };

            await _autenticacaoRepositorio.RegistrarAsync(usuario, registrarUsuarioCommand.Password);
            return Return(await GerarJwt(usuario.Email));
        }

        private async Task<LoginResponse> GerarJwt(string email)
        {
            var usuario = await BuscarEmailAsync(email);
            var claims = await BuscarClaimsUsuario(usuario);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_identitySettings.Secret);
            
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            {
                Issuer = _identitySettings.Emissor,
                Audience = _identitySettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_identitySettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return new LoginResponse 
            {
                ExpiresIn = TimeSpan.FromHours(_identitySettings.ExpiracaoHoras).TotalSeconds,
                Token = encodedToken,
                Usuario = new UsuarioResponse 
                {
                    Id = Guid.Parse(usuario.Id),
                    Email = usuario.Email,
                    Permissoes = claims.Select(x => new PermissoesResponse {  Type = x.Type, Value = x.Value })
                }
            };
        }

        private async Task<IList<Claim>> BuscarClaimsUsuario(IdentityUser usuario)
        {
            return await _userManager.GetClaimsAsync(usuario);
        } 

        private async Task<IdentityUser> BuscarEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
