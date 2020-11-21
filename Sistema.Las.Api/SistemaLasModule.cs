using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Las.Aplicacao.Autenticacao.Interfaces;
using Sistema.Las.Aplicacao.Autenticacao.Services;
using Sistema.Las.Aplicacao.Categorias.Handlers;
using Sistema.Las.Aplicacao.Categorias.Interfaces;
using Sistema.Las.Aplicacao.Interfaces;
using Sistema.Las.Aplicacao.Servicos;
using Sistema.Las.Domain.Autenticacao.Repositorios;
using Sistema.Las.Domain.Categorias.Comandos;
using Sistema.Las.Domain.Categorias.Repositorios;
using Sistema.Las.Domain.Categorias.Validacoes;
using Sistema.Las.Infra.Contextos;
using Sistema.Las.Infra.Repositorios;
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
            RegistrarHandlers(services);
            RegistrarValidacoes(services);

            return services;
        }

        private static void RegisterRepositorio(IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IAutenticacaoRepositorio, AutenticacaoRepositorio>();
        }

        private static void RegisterServicos(IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            
        }

        private static void RegistrarHandlers(IServiceCollection services)
        {
            services.AddScoped<ICriaCategoriaCommandHandler, CriaCategoriaCommandHandler>();
        }

        private static void RegistrarValidacoes(IServiceCollection services)
        {
            services.AddScoped<IValidator<CriaCategoriaCommand>, CriaCategoriaCommandValidator>();
        }
    }
}
