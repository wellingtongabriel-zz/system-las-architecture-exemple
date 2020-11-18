using AutoMapper;
using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Categorias.Entidades;

namespace Sistema.Las.Aplicacao.AutoMapper.Profiles
{
    public class commandProfile : Profile
    {
        public commandProfile()
        {
            CreateMap<CriaCategoriaCommand, Categoria>().ReverseMap();
        }
    }
}
