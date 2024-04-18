using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessEntities.Request
{
    public class ListarInmueblesRequest
    {
        public int? InmuebleID { get; set; }

        public int TipoInmuebleID { get; set; }
    }
}
