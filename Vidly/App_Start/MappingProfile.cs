using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(src => src.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(src => src.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}