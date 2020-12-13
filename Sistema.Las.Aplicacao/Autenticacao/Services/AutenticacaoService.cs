using AutoMapper;
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
using Sistema.Las.Domain.Genericos.Notificacao;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Las.Aplicacao.Autenticacao.Services
{
    public class AutenticacaoService : CommandHandlerBase, IAutenticacaoService
    {
        private readonly INotificacao _notificacao;
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        private readonly IdentitySettings _identitySettings;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AutenticacaoService (
            INotificacao notificacao,
            IAutenticacaoRepositorio autenticacaoRepositorio,
            IOptions<IdentitySettings> identitySettings,
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _notificacao = notificacao;
            _autenticacaoRepositorio = autenticacaoRepositorio;
            _identitySettings = identitySettings.Value;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result> LogarUsuario(LoginCommand logarCommand)
        {
            var response = await _autenticacaoRepositorio.Login(logarCommand.Email, logarCommand.Password);
            if (!response.Succeeded)
            {
                _notificacao.Handle("Usuário ou Senha inválida, tente novamente!");
                return Return();
            }

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

            var response = await _autenticacaoRepositorio.RegistrarAsync(usuario, registrarUsuarioCommand.Password);
            if (!response.Succeeded)
            {
                foreach (var erro in response.Errors)
                    _notificacao.Handle(erro.Description);

                return Return();
            }

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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return new LoginResponse 
            {
                ExpiresIn = TimeSpan.FromHours(_identitySettings.ExpiracaoHoras).TotalSeconds,
                Token = tokenHandler.WriteToken(token),
                Usuario = new UsuarioResponse 
                {
                    Id = Guid.Parse(usuario.Id),
                    Email = usuario.Email,
                    Permissoes = _mapper.Map<IEnumerable<PermissoesResponse>>(claims)
                }
            };
        }

        private async Task<IList<Claim>> BuscarClaimsUsuario(IdentityUser usuario) 
            =>  await _userManager.GetClaimsAsync(usuario);

        private async Task<IdentityUser> BuscarEmailAsync(string email) 
            => await _userManager.FindByEmailAsync(email);
    }
}