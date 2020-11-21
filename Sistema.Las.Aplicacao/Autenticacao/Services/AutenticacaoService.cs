using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sistema.Las.Api.Configuracoes.Indentity.Extensions;
using Sistema.Las.Aplicacao.Autenticacao.Contratos;
using Sistema.Las.Aplicacao.Autenticacao.Interfaces;
using Sistema.Las.Domain.Autenticacao.Comandos;
using Sistema.Las.Domain.Autenticacao.Repositorios;
using Sistema.Las.Domain.Genericos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Autenticacao.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        private readonly IdentitySettings _identitySettings;

        public AutenticacaoService (
            IAutenticacaoRepositorio autenticacaoRepositorio,
            IOptions<IdentitySettings> identitySettings)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
            _identitySettings = identitySettings.Value;
        }

        public async Task<IResult> LogarUsuario(LoginCommand logarCommand)
        {
            await _autenticacaoRepositorio.Login(logarCommand.Email, logarCommand.Password);
            return new Result(new LoginResponse 
            {
                Email = logarCommand.Email,
                Token = GerarJwt()
            });
        }

        public async Task<IResult> RegistarUsuario(RegistrarUsuarioCommand registrarUsuarioCommand)
        {
            var usuario = new IdentityUser
            {
                UserName = registrarUsuarioCommand.Nome,
                Email = registrarUsuarioCommand.Email,
                EmailConfirmed = true
            };

            await _autenticacaoRepositorio.RegistrarAsync(usuario, registrarUsuarioCommand.Password);
            return new Result(new RegistrarResponse
            {
                Email = usuario.Email,
                Nome = usuario.UserName,
                Token = GerarJwt()
            });
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_identitySettings.Secret);
            
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            {
                Issuer = _identitySettings.Emissor,
                Audience = _identitySettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_identitySettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }
    }
}
