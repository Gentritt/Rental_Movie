using AutoMapper;
using Rental_Movie.Dtos;
using Rental_Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.App_Start
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<CustomerDto, Customer>();

			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MovieDto, Movie>();

			Mapper.CreateMap<MembershipType, membershipTypeDto>();
			Mapper.CreateMap<Genre, GenreDto>();

			Mapper.CreateMap<Rental, RentalDto>();
			Mapper.CreateMap<Movie, MovieDtoTest>();
			Mapper.CreateMap<Customer, CustomerDtoTest>();

			Mapper.CreateMap<CustomerDto, Customer>()
					  .ForMember(c => c.Id, opt => opt.Ignore());

			Mapper.CreateMap<MovieDto, Movie>()
					.ForMember(c => c.Id, opt => opt.Ignore());
		}
	}
}	