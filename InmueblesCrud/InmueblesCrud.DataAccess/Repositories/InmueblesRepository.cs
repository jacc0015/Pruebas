using InmueblesCrud.BusinessEntities.Models;
using InmueblesCrud.BusinessEntities.ViewModels;
using InmueblesCrud.DataAccess.Contracts;
using InmueblesCrud.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace InmueblesCrud.DataAccess.Repositories
{
    public class InmueblesRepository : IInmueblesRepository
    {

        private readonly InmueblesDbContext _context;


        public InmueblesRepository(InmueblesDbContext context)
        {
            _context = context;
        }

        public async Task EliminarInmueble(int InmuebleID)
        {
            var inmbuele = _context.Inmuebles.FirstOrDefault(x => x.InmuebleID == InmuebleID);
            _context.Inmuebles.Remove(inmbuele);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<InmueblesOutputModel>> ListarInmbuebles(ListarInmueblesInputModel request)
        {
            var query = from i in _context.Inmuebles
                        join ti in _context.TipoInmuebles
                        on i.TipoInmuebleID equals ti.TipoInmuebleId
                        into ti2
                        from tipoInmueble in ti2.DefaultIfEmpty()
                        where request.InmuebleID == i.InmuebleID
                        select new InmueblesOutputModel
                        {
                            InmuebleID = i.InmuebleID,
                            Nombre = i.Nombre,
                            TipoInmuebleID = i.TipoInmuebleID,
                            Descripcion = i.Descripcion,
                            Direccion = i.Direccion,
                            Ciudad = i.Ciudad,
                            Pais = i.Pais,
                            Precio = i.Precio,
                            NumeroHabitaciones = i.NumeroHabitaciones,
                            NumeroBanos = i.NumeroBanos,
                            AreaMetrosCuadrados = i.AreaMetrosCuadrados,
                            AnioConstruccion = i.AnioConstruccion,

                        };


            return query;
        }

        public async Task RegistrarInmueble(RegistrarInmueblesInputModel registrarInmueblesInputModel)
        {
            _context.Inmuebles.Add(new Inmueble{
                Nombre = registrarInmueblesInputModel.Nombre,
                TipoInmuebleID = registrarInmueblesInputModel.TipoInmuebleID,
                Descripcion = registrarInmueblesInputModel.Descripcion,
                Direccion = registrarInmueblesInputModel.Direccion,
                Ciudad = registrarInmueblesInputModel.Ciudad,
                Pais = registrarInmueblesInputModel .Pais,
                Precio = registrarInmueblesInputModel.Precio,
                NumeroHabitaciones = registrarInmueblesInputModel.NumeroHabitaciones,
                NumeroBanos = registrarInmueblesInputModel.NumeroBanos,
                AreaMetrosCuadrados = registrarInmueblesInputModel.AreaMetrosCuadrados,
                AnioConstruccion = registrarInmueblesInputModel.AnioConstruccion
            });;
           _context.SaveChanges();
        }

        public async Task ActualizarInmueble(ActualizarInmueblesInputModel actualizarInmueblesInputModel)
        {
            var inmueble =  _context.Inmuebles.FirstOrDefault( x => x.InmuebleID == actualizarInmueblesInputModel.InmuebleID);
            inmueble.Nombre = actualizarInmueblesInputModel.Nombre ?? inmueble.Nombre;
            inmueble.TipoInmuebleID = actualizarInmueblesInputModel.TipoInmuebleID ?? inmueble.TipoInmuebleID;
            inmueble.Descripcion = actualizarInmueblesInputModel.Descripcion ?? inmueble.Descripcion;
            inmueble.Direccion = actualizarInmueblesInputModel.Direccion ?? inmueble.Direccion;
            inmueble.Ciudad = actualizarInmueblesInputModel.Ciudad ?? inmueble.Ciudad;
            inmueble.Pais = actualizarInmueblesInputModel.Pais ?? inmueble.Pais;
            inmueble.Precio = actualizarInmueblesInputModel.Precio ?? inmueble.Precio;
            inmueble.NumeroHabitaciones = actualizarInmueblesInputModel.NumeroHabitaciones ?? inmueble.NumeroHabitaciones;
            inmueble.NumeroBanos = actualizarInmueblesInputModel.NumeroBanos ?? inmueble.NumeroBanos;
            inmueble.AreaMetrosCuadrados = actualizarInmueblesInputModel.AreaMetrosCuadrados ?? inmueble.AreaMetrosCuadrados;
            inmueble.AnioConstruccion = actualizarInmueblesInputModel.AnioConstruccion ?? inmueble.AnioConstruccion;

            _context.Inmuebles.Update(inmueble);
            await _context.SaveChangesAsync();
        }
    }
}
