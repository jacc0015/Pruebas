using FluentValidation;
using InmueblesCrud.Api.Validators;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessLogic;
using InmueblesCrud.DataAccess;

namespace InmueblesCrud.Api
{
    public static class BussinessLogicInjection
    {

        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<ListarInmueblesRequest>, ListarInmueblesRequestValidator>(); 
            services.AddTransient<IValidator<RegistrarInmuebleRequest>, RegistrarInmuebleRequestValidator>();

            services.AddLogicBussinessLogic();
            services.AddRepositories(configuration);
        }
    }
}
