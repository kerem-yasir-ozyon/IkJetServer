using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using IkJet.DAL.Profiles;
using IkJet.DAL.Repositories.Concrete;
using IkJet.DAL.Services.Abstract;
using IkJet.DTO.Concrete;
using IkJet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Services.Concrete
{
	public class CompanyService : Service<Company, CompanyDto>
	{
        public CompanyService(CompanyRepo repo) : base(repo)
		{

			MapperConfiguration _config = new MapperConfiguration(cfg =>
			{
				cfg.AddExpressionMapping().AddCollectionMappers();
				cfg.AddProfile<CompanyProfile>();
			});
			base._mapper = _config.CreateMapper();

		}

    }
}
