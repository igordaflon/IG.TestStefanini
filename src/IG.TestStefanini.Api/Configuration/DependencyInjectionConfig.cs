using IG.TestStefanini.Business.Interfaces;
using IG.TestStefanini.Business.Notificacoes;
using IG.TestStefanini.Business.Services;
using IG.TestStefanini.Data.Context;
using IG.TestStefanini.Data.Repository;

namespace IG.TestStefanini.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<TestStefaniniDbContext>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IPessoaService, PessoaService>();

            return services;
        }
    }
}
