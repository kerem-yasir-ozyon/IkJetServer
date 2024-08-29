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
	public class CompanyRepo : Repo<Company>
	{
		public CompanyRepo(IkJetDbContext dbContext) : base(dbContext)
		{
		}


	}
}
