using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Las.Infra.Contextos;
using System;

namespace Sistema.Las.Api
{
    public static class SistemaLasModule
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Type type)
        {
            services.AddScoped<DbContext, SistemaLasContexto>();

            RegisterRepositorio(services);
            RegisterServicos(services);

            return services;
        }

        private static void RegisterRepositorio(IServiceCollection services)
        {

        }

        private static void RegisterServicos(IServiceCollection services)
        {

        }
    }
}
