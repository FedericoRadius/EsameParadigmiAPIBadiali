using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Applicazione.Servizi;
using FluentValidation;

namespace EsameParadigmiAPIBadiali.Applicazione.Estensioni
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
            AppDomain.CurrentDomain.GetAssemblies().
                SingleOrDefault(assembly => assembly.GetName().Name == "EsameParadigmiAPIBadiali")
            );

            services.AddScoped<IServizioLibri, ServizioLibri>();
            services.AddScoped<IServizioCategorie, ServizioCategorie>();
            services.AddScoped<IServizioUtenti, ServizioUtenti>();
            services.AddScoped<IServizioToken, ServizioToken>(); 
            return services;
        }
    }
}
