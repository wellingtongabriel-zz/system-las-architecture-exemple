using AutoMapper;
using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Categorias.Entidades;

namespace Sistema.Las.Aplicacao.AutoMapper.Profiles
{
    public class commandParaEntidade : Profile
    {
        public commandParaEntidade()
        {
            CreateMap<CriaCategoriaCommand, Categoria>().ReverseMap();
        }
    }
}
