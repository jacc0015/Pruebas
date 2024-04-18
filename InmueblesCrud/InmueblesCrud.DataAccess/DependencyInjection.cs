using InmueblesCrud.DataAccess.Contracts;
using InmueblesCrud.DataAccess.Data;
using InmueblesCrud.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmueblesCrud.DataAccess;
public static class DependencyInjection
{

    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IInmueblesRepository, InmueblesRepository>();
        services.AddTransient<ITipoInmuebleRepository, TipoInmuebleRepository>();
        services.AddDbContext<InmueblesDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("InmueblesConnection")));
    }

}
