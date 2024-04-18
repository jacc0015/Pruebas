using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessEntities.ViewModels
{
    public class ListarInmueblesInputModel
    {
        public int? InmuebleID { get; set; }

        public int TipoInmuebleID { get; set; }
    }
}
