using FluentValidation;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.ViewModels;

namespace InmueblesCrud.Api.Validators
{
    public class ListarInmueblesRequestValidator : AbstractValidator<ListarInmueblesRequest>
    {
        public ListarInmueblesRequestValidator()
        {
            RuleFor(x => x.InmuebleID)
                   .NotEmpty()
                       .WithMessage(string.Format(ErrorDescription._4001, "IdInmueble"))
                       .WithErrorCode(ErrorCode._4001)
                   .NotNull()
                       .WithMessage(string.Format(ErrorDescription._4001, "IdInmueble"))
                       .WithErrorCode(ErrorCode._4001);
        }


    }
}
