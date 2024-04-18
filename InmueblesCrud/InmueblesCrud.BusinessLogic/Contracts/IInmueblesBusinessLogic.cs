using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.Response;
using InmueblesCrud.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessLogic.Contracts
{
    public interface IInmueblesBusinessLogic
    {
        Task<GlobalResponse<InmueblesRespuestaViewModel>> ListarInmuebles(ListarInmueblesRequest request);

        Task<GlobalResponse<object>>  EliminarInmueble(int InmuebleID);

        Task<GlobalResponse<object>> ActualizarInmueble(ActualizarInmuebleRequest request);

        Task<GlobalResponse<object>> RegistrarInmueble(RegistrarInmuebleRequest request);

    }
}
