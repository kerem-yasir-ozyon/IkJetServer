using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Profiles
{
	public class CompanyProfile : Profile
	{
        public CompanyProfile()
        {

			CreateMap<CompanyViewModel, CompanyDto>().ForMember(dest => dest.AppUsers, opt => opt.MapFrom(src => src.AppUsers)).ReverseMap();

			CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses)).ReverseMap();
			CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments)).ReverseMap();
			CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs)).ReverseMap();
		}

    }
}
