using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Las.Api.Configuracoes.AutoMapper.Profiles;
using Sistema.Las.Aplicacao.AutoMapper.Profiles;

namespace Sistema.Las.Aplicacao.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterAutoMapper(this IServiceCollection services) 
        {
            var configuracao = ConfigureAutoMapper();
            services.AddScoped(x => configuracao.CreateMapper());
            return configuracao;
        }

        public static MapperConfiguration ConfigureAutoMapper()
        {
            return new MapperConfiguration(configuracao => {
                configuracao.AddProfile(new commandProfile());
                configuracao.AddProfile(new ResponseProfile());
            });
        }
    }
}
