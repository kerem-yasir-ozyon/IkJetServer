using AutoMapper;
using IkJet.DTO.Abstract;
using IkJet.DTO.Concrete;
using IkJet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Abstract
{
    public interface IManager<TDto, TViewModel>
        where TDto : BaseDto
        where TViewModel : BaseViewModel
    {
        IMapper Mapper { set; }
        int Add(TViewModel viewModel);
        int Update(TViewModel viewModel);
        int Delete(TViewModel viewModel);
        int Delete(int id);
        int Remove(TViewModel viewModel);
        IEnumerable<TViewModel> GetAll();
        TViewModel? Get(int id);
        IEnumerable<TViewModel> GetByUserRequestList(int userId);

    }
}
