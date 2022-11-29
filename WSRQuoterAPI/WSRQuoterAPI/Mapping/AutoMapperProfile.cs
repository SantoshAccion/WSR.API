using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using WSRQuoterAPI.Models;
using WSRQuoterAPI.Models.USDADtos;

namespace WSRQuoterAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StateDto, State>();
            CreateMap<CountyDto, County>();
            CreateMap<String, SubCounty>().ForMember
                (dest => dest.GridId, opt => opt.MapFrom(src => src));
            CreateMap<int, RainfallYear>().ForMember
                (dest => dest.Year, opt => opt.MapFrom(src => src));
        }
    }
}
