using FluentValidation.Results;
using InmueblesCrud.BusinessEntities.ViewModels;

namespace InmueblesCrud.Api.Filters
{
    public class ValidationResultModel
    {
        public HeadGlobalResponse Cabecera { get; set; }

        public ValidationResultModel(string error, string errorDescription)
        {
            Cabecera = new HeadGlobalResponse();
            Cabecera.CodigoRespuesta = error;
            Cabecera.MensajeRespuesta = errorDescription;
        }

        public ValidationResultModel(ValidationResult result)
        {
            Cabecera = new HeadGlobalResponse();
            Cabecera.CodigoRespuesta = result.Errors.Select(x => x.ErrorCode).FirstOrDefault() ?? string.Empty;
            Cabecera.MensajeRespuesta = result.Errors.Select(x => x.ErrorMessage).FirstOrDefault() ?? string.Empty;
        }
    }
}
