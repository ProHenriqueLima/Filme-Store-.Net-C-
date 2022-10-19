using TesteWiPro.Business.Interfaces;
using TesteWiPro.Business.Services;
using TesteWiPro.Data.Repositories;

namespace TesteWiPro.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();
            services.AddScoped<IAluguelService, AluguelService>();


            return services;
        }
    }

}
