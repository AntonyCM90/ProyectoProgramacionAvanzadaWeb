using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Guia, DataModels.Guia>().ReverseMap();
            CreateMap<data.Tour, DataModels.Tour>().ReverseMap();
            CreateMap<data.Reserva, DataModels.Reserva>().ReverseMap();
        }
    }
}
