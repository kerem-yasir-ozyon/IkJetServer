using IkJet.BLL.Managers.Abstract;
using IkJet.DAL.Services.Concrete;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.Prepayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Concrete
{
    public class PrepaymentManager : Manager<PrepaymentDto,PrepaymentViewModel, Prepayment>
    {
        public PrepaymentManager(PrepaymentService service) : base(service)
        {
        }
    }
}
