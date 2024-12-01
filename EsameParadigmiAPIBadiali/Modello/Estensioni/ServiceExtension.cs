using EsameParadigmiAPIBadiali.Modelli.Repositories;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EsameParadigmiAPIBadiali.Modello.Estensioni
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<LibroRepository>();
            services.AddScoped<UtenteRepository>();
            services.AddScoped<CategorieRepository>();
            return services;
        }
    }
}
