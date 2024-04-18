using AutoMapper;
using InmueblesCrud.BusinessEntities.Exceptions;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.Response;
using InmueblesCrud.BusinessEntities.ViewModels;
using InmueblesCrud.BusinessLogic.Contracts;
using InmueblesCrud.DataAccess.Contracts;
using InmueblesCrud.DataAccess.Repositories;


namespace InmueblesCrud.BusinessLogic.Implementations
{
    public class InmueblesBusinessLogic : IInmueblesBusinessLogic
    {

        private readonly IInmueblesRepository _inmueblesRepository;
        private readonly ITipoInmuebleRepository _tipoInmuebleRepository;
        public readonly IMapper _mapper;

        public InmueblesBusinessLogic(IInmueblesRepository inmueblesRepository,
                                ITipoInmuebleRepository tipoInmuebleRepository,
                                IMapper mapper)
        {
            _inmueblesRepository = inmueblesRepository;
            _mapper = mapper;
            _tipoInmuebleRepository = tipoInmuebleRepository;
        }

        public async Task<GlobalResponse<InmueblesRespuestaViewModel>> ListarInmuebles(ListarInmueblesRequest request)
        {
            var inputModel = _mapper.Map<ListarInmueblesRequest, ListarInmueblesInputModel>(request);
            IEnumerable<InmueblesOutputModel> outputModel = await _inmueblesRepository.ListarInmbuebles(inputModel);
            IEnumerable<InmuebleViewModel> result = _mapper.Map<IEnumerable<InmueblesOutputModel>, IEnumerable<InmuebleViewModel>>(outputModel);
            return new GlobalResponse<InmueblesRespuestaViewModel>(new InmueblesRespuestaViewModel
            {
                ListaInmuebles = result.ToList()
            });
        }

        public async Task<GlobalResponse<object>> EliminarInmueble(int InmuebleID)
        {
           await _inmueblesRepository.EliminarInmueble(InmuebleID);
            return new GlobalResponse<object> { };
        }

        public async Task<GlobalResponse<object>> ActualizarInmueble(ActualizarInmuebleRequest request)
        {
            IEnumerable<InmueblesOutputModel> inmueble = await _inmueblesRepository.ListarInmbuebles(new ListarInmueblesInputModel
            {
                InmuebleID = request.InmuebleID
            });
            if(!inmueble.Any())
            {
                throw new DataNotFoundException(string.Format(ErrorDescription._1001,"Inmueble", request.InmuebleID));
            }
            var inputModel = _mapper.Map<ActualizarInmuebleRequest, ActualizarInmueblesInputModel>(request);

            await _inmueblesRepository.ActualizarInmueble(inputModel);
            return new GlobalResponse<object> { };
        }

        public async Task<GlobalResponse<object>> RegistrarInmueble(RegistrarInmuebleRequest request)
        {
            IEnumerable<TipoInmuebleOutputModel> tipoInmueble = await _tipoInmuebleRepository.obtenerTipoInmbueble(new ListarTipoInmuebleInputModel
            {
                TipoInmuebleId = request.TipoInmuebleID
            });
            if (!tipoInmueble.Any())
            {
                throw new DataNotFoundException(string.Format(ErrorDescription._1001, "TipoInmueble", request.TipoInmuebleID));
            }

            var inputModel = _mapper.Map<RegistrarInmuebleRequest, RegistrarInmueblesInputModel>(request);


            await _inmueblesRepository.RegistrarInmueble(inputModel);
            return new GlobalResponse<object> { };
        }
    }

}
