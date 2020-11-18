using AutoMapper;
using Sistema.Las.Aplicacao.Contratos;
using Sistema.Las.Domain.Categorias.Entidades;

namespace Sistema.Las.Api.Configuracoes.AutoMapper.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<CategoriaResponse, Categoria>().ReverseMap();
        }
    }
}
