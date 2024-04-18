using FluentValidation;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessLogic.Contracts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using InmueblesCrud.Api.Filters;
using Microsoft.VisualBasic;

namespace InmueblesCrud.Api.Controllers
{

    [ApiController]
    [Route("Inmuebles")]
    public class InmueblesController : ControllerBase
    {
        private readonly IInmueblesBusinessLogic _iInmueblesBusinessLogic;
        private readonly IValidator<ListarInmueblesRequest> _listarInmueblesRequestValidator;
        private readonly IValidator<RegistrarInmuebleRequest> _registrarInmuebleRequest;


        public InmueblesController( IInmueblesBusinessLogic iInmueblesBusinessLogic,
            IValidator<ListarInmueblesRequest> listarInmueblesRequestValidator ,
            IValidator<RegistrarInmuebleRequest> registrarInmuebleRequest)
        {
            _iInmueblesBusinessLogic = iInmueblesBusinessLogic;
            _listarInmueblesRequestValidator = listarInmueblesRequestValidator;
            _registrarInmuebleRequest = registrarInmuebleRequest;
        }

        [HttpGet]
        public async Task<IActionResult> ListarInmuebles([FromQuery] ListarInmueblesRequest request)
        {
            var resultsValidations = await _listarInmueblesRequestValidator.ValidateAsync(request);
            resultsValidations.AddToModelState(ModelState, null);
            if (!resultsValidations.IsValid)
            { 
                return new ValidationFailedResult(resultsValidations);
            }
            var result = await _iInmueblesBusinessLogic.ListarInmuebles(request);   

            return Ok(result);

        }


        [HttpDelete]
        public async Task<IActionResult> EliminarInmuebles([FromQuery] int InmuebleId)
        {
           var result =  await _iInmueblesBusinessLogic.EliminarInmueble(InmuebleId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarInmueble([FromBody] ActualizarInmuebleRequest request)
        {
            var result = await _iInmueblesBusinessLogic.ActualizarInmueble(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarInmueble([FromBody] RegistrarInmuebleRequest request)
        {

            var resultsValidations = await _registrarInmuebleRequest.ValidateAsync(request);
            resultsValidations.AddToModelState(ModelState, null);
            if (!resultsValidations.IsValid)
            {
                return new ValidationFailedResult(resultsValidations);
            }
            var result = await _iInmueblesBusinessLogic.RegistrarInmueble(request);
            return Ok(result);
        }
    }
}
