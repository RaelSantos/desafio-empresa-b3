using B3.CDB.Business.Intefaces;
using B3.CDB.Business.Notificacoes;
using B3.CDB.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace B3.CDB.Api.Setup
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //services.AddScoped<MeuDbContext>();
            //services.AddScoped<IProdutoRepository, ProdutoRepository>();            

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IInvestimentoService, InvestimentoService>();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
