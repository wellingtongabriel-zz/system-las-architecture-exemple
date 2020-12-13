using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sistema.Las.Api
{
    public class Program
    {
        public static void Main(string[] args) 
            => CreateHostBuilder(args)
                .Build()
                .Run();


        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(opts =>
                {
                    opts.UseStartup<Startup>();
                    opts.UseIISIntegration();
                    opts.UseHttpSys(cfg =>
                    {
                        cfg.UrlPrefixes.Add("http://*:8001");
                    });
                });
    }
}
