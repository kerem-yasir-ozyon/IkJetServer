using AutoMapper;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.AppUser;
using IkJet.ViewModel.Expense;
using IkJet.ViewModel.Prepayment;
using IkJet.ViewModel.WorkOff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Profiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserViewModel, AppUser>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses))
                                                     .ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments))
                                                     .ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs))
                                                     .ReverseMap();

            CreateMap<AppUserViewModel, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses))
                                                     .ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments))
                                                     .ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs))
                                                     .ReverseMap();

            CreateMap<ExpenseViewModel, ExpenseDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            CreateMap<PrepaymentViewModel, PrepaymentDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
            CreateMap<WorkOffViewModel, WorkOffDto>().ForMember(dest => dest.AppUser, opt => opt.Ignore()).ReverseMap();
        }
    }
}
