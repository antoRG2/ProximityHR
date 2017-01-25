using AutoMapper;
using Proximity.HR.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Data
{
    public class MappingBase
    {
        public static void Configure()
        {
            Mapper.CreateMap<City, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<State, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<Country, GeneralCollectionItemDto>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Name));

        }
    }
}
