using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessEntities.Response
{
    public class InmueblesRespuestaViewModel
    {

        public List<InmuebleViewModel> ListaInmuebles { get; set; }


    }
    public class InmuebleViewModel
    {
        public int InmuebleID { get; set; }
        public string Nombre { get; set; }
        public int TipoInmuebleID { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public decimal Precio { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int NumeroBanos { get; set; }
        public decimal AreaMetrosCuadrados { get; set; }
        public int AnioConstruccion { get; set; }
    }
}