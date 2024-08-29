using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Profiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserViewModel, AppUser>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses))
                                                     .ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments))
                                                     .ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs))
                                                     .ReverseMap();

            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses))
                                                .ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments))
                                                .ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs))
                                                .ReverseMap();

            CreateMap<Expense, ExpenseDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            CreateMap<Prepayment, PrepaymentDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            CreateMap<WorkOff, WorkOffDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();


        }
    }
}
