using InmueblesCrud.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.DataAccess.Contracts
{
    public interface ITipoInmuebleRepository
    {
        Task<IQueryable<TipoInmuebleOutputModel>> obtenerTipoInmbueble(ListarTipoInmuebleInputModel request);
    }
}
