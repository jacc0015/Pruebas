using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.ViewModels;

namespace InmueblesCrud.DataAccess.Contracts
{
    public interface IInmueblesRepository
    {
        Task<IQueryable<InmueblesOutputModel>> ListarInmbuebles(ListarInmueblesInputModel request);

        Task RegistrarInmueble(RegistrarInmueblesInputModel registrarInmueblesInputModel);

        Task ActualizarInmueble(ActualizarInmueblesInputModel actualizarInmueblesInputModel);

        Task EliminarInmueble(int InmuebleID);
    }
}
