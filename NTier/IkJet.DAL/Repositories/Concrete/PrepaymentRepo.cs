using IkJet.DAL.Data;
using IkJet.DAL.Repositories.Abstract;
using IkJet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Repositories.Concrete
{
    public class PrepaymentRepo : Repo<Prepayment>
    {
        public PrepaymentRepo(IkJetDbContext dbContext) : base(dbContext)
        {
        }
    }
}
