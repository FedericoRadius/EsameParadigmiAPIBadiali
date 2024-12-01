using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using EsameParadigmiAPIBadiali.Web.Risultati;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Options;

namespace EsameParadigmiAPIBadiali.Web.Estensioni
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestResultFactory(context);
                    };
                });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API esame paradigmi traccia N01"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            services.AddFluentValidationAutoValidation();

            var jwtAuthenticationOption = new JwtAuthenticationOption(); 
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthenticationOption);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    string key = jwtAuthenticationOption.Key;
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)
                        );
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAuthenticationOption.Issuer,
                        IssuerSigningKey = securityKey
                    };
                });


            services.AddOptions(configuration);

            return services;
        }


        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //Prendo il singolo valore
            //string host = configuration
            //    .GetValue<string>("EmailOption:Host");
            //Prendo un oggetto e lo bindo alla sezione una tantum
            //var emailOption = new EmailOption();
            //configuration.GetSection("EmailOption")
            //    .Bind(emailOption);
            //Pattern Options : Prendo l'oggetto e lo dichiaro come servizio
            //services.Configure<EmailOption>(
            //    configuration.GetSection("EmailOption")
            //    );

            services.Configure<JwtAuthenticationOption>(
                configuration.GetSection("JwtAuthentication")
                );

            return services;
        }
    }
}
