using FluentValidation;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.ViewModels;

namespace InmueblesCrud.Api.Validators
{
    public class RegistrarInmuebleRequestValidator : AbstractValidator<RegistrarInmuebleRequest>
    {

        public RegistrarInmuebleRequestValidator()
        {
            RuleFor(x => x.Nombre)
                 .NotEmpty()
                     .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                     .WithErrorCode(ErrorCode._4001)
                 .NotNull()
                     .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                     .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.TipoInmuebleID)
               .NotEmpty()
                   .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                   .WithErrorCode(ErrorCode._4001)
               .NotNull()
                   .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                   .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                    .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                    .WithErrorCode(ErrorCode._4001)
                .NotNull()
                    .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                    .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.Direccion)
              .NotEmpty()
                  .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                  .WithErrorCode(ErrorCode._4001)
              .NotNull()
                  .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                  .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.Ciudad)
             .NotEmpty()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001)
             .NotNull()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.Pais)
             .NotEmpty()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001)
             .NotNull()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.Precio)
             .NotEmpty()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001)
             .NotNull()
                 .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                 .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.NumeroHabitaciones)
            .NotEmpty()
                .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                .WithErrorCode(ErrorCode._4001)
            .NotNull()
                .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.NumeroBanos)
            .NotEmpty()
              .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
              .WithErrorCode(ErrorCode._4001)
          .NotNull()
              .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
              .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.AreaMetrosCuadrados)
                .NotEmpty()
                  .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                  .WithErrorCode(ErrorCode._4001)
              .NotNull()
                  .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                  .WithErrorCode(ErrorCode._4001);
            RuleFor(x => x.AnioConstruccion)
              .NotEmpty()
                .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                .WithErrorCode(ErrorCode._4001)
            .NotNull()
                .WithMessage(string.Format(ErrorDescription._4001, "{PropertyName}"))
                .WithErrorCode(ErrorCode._4001);

        }
    }
}
