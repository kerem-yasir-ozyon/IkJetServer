using IkJet.BLL.Managers.Abstract;
using IkJet.DAL.Services.Concrete;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using IkJet.ViewModel.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Concrete
{
    public class ExpenseManager : Manager<ExpenseDto,ExpenseViewModel,Expense>
    {
        public ExpenseManager(ExpenseService service) : base(service)
        {
        }
    }
}
