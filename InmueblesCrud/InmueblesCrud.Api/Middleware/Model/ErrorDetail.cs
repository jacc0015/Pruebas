using Newtonsoft.Json;

namespace InmueblesCrud.Api.Middlewares.Model
{
    public class ErrorDetail
    {
        public HeadErrorDetail Cabecera { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class HeadErrorDetail
    {
        public HeadErrorDetail(string codigoRespuesta, string mensajeRespuesta)
        {
            CodigoRespuesta = codigoRespuesta;
            MensajeRespuesta = mensajeRespuesta;
        }

        public string CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
