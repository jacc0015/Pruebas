using InmueblesCrud.BusinessLogic.Contracts;
using InmueblesCrud.BusinessLogic.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessLogic
{
    public static class DependencyInjection
    {
        public static void AddLogicBussinessLogic(this IServiceCollection services)
        {
               services.AddTransient<IInmueblesBusinessLogic, InmueblesBusinessLogic>();
        }
    }
}
