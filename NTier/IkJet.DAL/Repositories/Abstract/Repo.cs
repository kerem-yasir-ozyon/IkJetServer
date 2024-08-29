using IkJet.Common.Enums;
using IkJet.DAL.Data;
using IkJet.Entities.Abstract;
using IkJet.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Repositories.Abstract
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
    {
        protected IkJetDbContext _dbContext;
        public Repo(IkJetDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        }
        public int Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
            
        }

        public int Delete(TEntity entity)
        {
            entity.IsDeleted = true;
           _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public TEntity? Get(int id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefault(e=>e.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }



        public int Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity>? GetByUserRequestList(int userId)
        {
            return _dbContext.Set<TEntity>().Where(e => EF.Property<int>(e, "AppUserId") == userId).ToList();
        }

        }
}
