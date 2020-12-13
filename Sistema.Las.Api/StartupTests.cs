using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sistema.Las.Api.Configuracoes.Indentity;
using Sistema.Las.Aplicacao.AutoMapper;
using Sistema.Las.Infra.Contextos;

namespace Sistema.Las.Api
{
    public class StartupTests
    {
        public IConfiguration _configuration { get; }
        public StartupTests(IWebHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(opt => opt.EnableEndpointRouting = false)
                .AddFluentValidation();

            services.RegisterServices(typeof(Startup));

            var stringConexao = _configuration.GetConnectionString("Default");
            services.AddDbContext<SistemaLasContexto>(opt => opt.UseSqlServer(stringConexao));

            services.AddIdentityConfiguration(_configuration);

            services.AddCors();
            services.RegisterAutoMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors(opt => 
                            opt.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());

            app.UseAuthentication();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
