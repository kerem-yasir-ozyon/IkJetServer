using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Profiles
{
	public class CompanyProfile : Profile
	{
        public CompanyProfile()
        {
			CreateMap<Company, CompanyDto>().ForMember(dest => dest.AppUsers, opt => opt.MapFrom(src => src.AppUsers)).ReverseMap();

			CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses)).ReverseMap();
			CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments)).ReverseMap();
			CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs)).ReverseMap();


		}

    }
}
