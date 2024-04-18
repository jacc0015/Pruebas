using AutoMapper;
using InmueblesCrud.BusinessEntities.Request;
using InmueblesCrud.BusinessEntities.Response;
using InmueblesCrud.BusinessEntities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessLogic.AutoMapper
{
    public class InmuebleProfile : Profile 
    {
        public InmuebleProfile() 
        {
            CreateMap<ListarInmueblesRequest, ListarInmueblesInputModel>()
                .ForPath(dest => dest.InmuebleID, opts => opts.MapFrom(src => src.InmuebleID))
                .ForPath(dest => dest.TipoInmuebleID, opts => opts.MapFrom(src => src.TipoInmuebleID));

            CreateMap<InmueblesOutputModel, InmuebleViewModel>();
          
            CreateMap<ActualizarInmuebleRequest, ActualizarInmueblesInputModel>();

            CreateMap<RegistrarInmuebleRequest, RegistrarInmueblesInputModel>();

        }
    }
}
