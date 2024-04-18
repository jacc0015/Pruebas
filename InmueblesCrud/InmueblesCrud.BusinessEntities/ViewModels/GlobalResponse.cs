using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessEntities.ViewModels
{
    public class GlobalResponse<T>
    {
        public GlobalResponse() {
            Cabecera = new HeadGlobalResponse();
            Cabecera.CodigoRespuesta = ErrorCode._0000;
            Cabecera.MensajeRespuesta = ErrorDescription._0000;
        }
        public GlobalResponse(T? detalle)
        {
            Detalle = detalle;
            Cabecera = new HeadGlobalResponse();
            Cabecera.CodigoRespuesta = ErrorCode._0000;
            Cabecera.MensajeRespuesta = ErrorDescription._0000;
        }

        public HeadGlobalResponse Cabecera { get; set; }
        public T? Detalle { get; set; }

    }
    public class HeadGlobalResponse
    {
        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }


    }
}
