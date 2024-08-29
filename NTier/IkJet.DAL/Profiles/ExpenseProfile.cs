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
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser)).ReverseMap();

            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses)).ReverseMap();
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.Prepayments, opt => opt.MapFrom(src => src.Prepayments)).ReverseMap();
            CreateMap<AppUser, AppUserDto>().ForMember(dest => dest.WorkOffs, opt => opt.MapFrom(src => src.WorkOffs)).ReverseMap();

        }
    }
}
