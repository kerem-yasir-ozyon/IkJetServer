using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.WorkOff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Profiles
{
    public class WorkOffProfile : Profile
    {
        public WorkOffProfile()
        {
            CreateMap<WorkOffViewModel, WorkOffDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser)).ReverseMap();

            CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses)).ReverseMap();
            CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments)).ReverseMap();
            CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs)).ReverseMap();
        }
    }
}
