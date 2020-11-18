using AutoMapper;
using Sistema.Las.Aplicacao.Contratos;
using Sistema.Las.Domain.Categorias.Entidades;

namespace Sistema.Las.Api.Configuracoes.AutoMapper.Profiles
{
    public class ResponseParaEntidade : Profile
    {
        public ResponseParaEntidade()
        {
            CreateMap<CategoriaResponse, Categoria>().ReverseMap();
        }
    }
}
