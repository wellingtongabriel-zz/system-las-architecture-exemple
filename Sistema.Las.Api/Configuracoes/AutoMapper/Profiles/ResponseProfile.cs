using AutoMapper;
using Sistema.Las.Aplicacao.Autenticacao.Contratos;
using Sistema.Las.Aplicacao.Contratos;
using Sistema.Las.Domain.Categorias.Entidades;
using System.Security.Claims;

namespace Sistema.Las.Api.Configuracoes.AutoMapper.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<CategoriaResponse, Categoria>().ReverseMap();
            CreateMap<PermissoesResponse, Claim>().ReverseMap();
        }
    }
}
