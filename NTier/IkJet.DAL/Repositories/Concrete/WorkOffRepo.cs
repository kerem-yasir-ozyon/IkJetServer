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
    public class WorkOffRepo : Repo<WorkOff>
    {
        public WorkOffRepo(IkJetDbContext dbContext) : base(dbContext)
        {
        }
    }
}
