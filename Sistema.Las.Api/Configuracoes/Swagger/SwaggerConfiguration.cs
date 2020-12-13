using Microsoft.AspNetCore.Builder;

namespace Sistema.Las.Api.Configuracoes.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IApplicationBuilder UseSwaggerESwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema LAS API");
            });

            return app;
        }
    }
}
