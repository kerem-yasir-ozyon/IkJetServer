using IkJet.Entities.Abstract;
using IkJet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Repositories.Abstract
{
    public interface IRepo<TEntity> where TEntity:BaseEntity
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity); 
        int Remove(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? Get(int id);
        IEnumerable<TEntity>? GetByUserRequestList(int userId);
    }
}
