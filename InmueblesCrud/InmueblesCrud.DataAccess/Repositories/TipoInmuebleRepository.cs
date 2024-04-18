using InmueblesCrud.BusinessEntities.ViewModels;
using InmueblesCrud.DataAccess.Contracts;
using InmueblesCrud.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.DataAccess.Repositories
{
    public class TipoInmuebleRepository : ITipoInmuebleRepository
    {

        private readonly InmueblesDbContext _context;

        public TipoInmuebleRepository(InmueblesDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<TipoInmuebleOutputModel>> obtenerTipoInmbueble(ListarTipoInmuebleInputModel request)
        {
            var query = from  ti in _context.TipoInmuebles
                         where request.TipoInmuebleId == ti.TipoInmuebleId
                        select new TipoInmuebleOutputModel
                        {
                            TipoInmuebleId = ti.TipoInmuebleId,
                            Descripcion = ti.Descripcion,
                       };


            return query;
        }
    }
}
