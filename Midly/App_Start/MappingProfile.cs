using AutoMapper;
using Midly.Dtos;
using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midly.App_Start
{
    public class MappingProfile : Profile
    {
        //Automapper is a convention based mapping tool
        public MappingProfile()
        {

            //Mappings for customer model
            Mapper.CreateMap<Customer, CustomerDto>();
            //ForMember() used when we update a customer, the id value should not be considered or you will get following error
            //Property id is a part of key information and cannot be updated
            //Therefore we are telling the auto mapper to ignore ID parameter
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());


            //Mapping for movie model
            Mapper.CreateMap<Movie, MovieDto>();
            //ForMember() used when we update a Movie, the id value should not be considered or you will get following error
            //Property id is a part of key information and cannot be updated
            //Therefore we are telling the auto mapper to ignore ID parameter
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


        }
    }
}