using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using IkJet.DAL.Repositories.Abstract;
using IkJet.DTO.Abstract;
using IkJet.DTO.Concrete;
using IkJet.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Services.Abstract
{
    public abstract class Service<TEntity, TDto> : IService<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected IMapper _mapper;
        public Repo<TEntity> _repo;

        public Service(Repo<TEntity> repo)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.CreateMap<TDto, TEntity>().ReverseMap();
            });
            _mapper = _config.CreateMapper();
            _repo = repo;
        }

        public IMapper Mapper
        {
            set { _mapper = value; }
        }

        public int Add(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Add(entity);
        }

        public int Delete(TDto dto)
        {
            TEntity entity= _mapper.Map<TEntity>(dto);
            return _repo.Delete(entity);
        }

        public int Delete(int id)
        {
            TDto dto = this.Get(id);
            return this.Delete(dto);
        }

        public TDto? Get(int id)
        {
            TEntity? entity= _repo.Get(id);
            TDto? dto=_mapper.Map<TDto>(entity);
            return dto;
        }

        public IEnumerable<TDto> GetAll()
        {
            IEnumerable<TEntity> entities = _repo.GetAll();
            IEnumerable<TDto> dtos=_mapper.Map<IEnumerable<TDto>>(entities.ToList());
            return dtos;
        }



        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            
            IEnumerable<TEntity> entities = await _repo.GetAllAsync();

            
            IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities.ToList());

            return dtos;
        }





        public int Remove(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            return _repo.Remove(entity);
        }

        public int Update(TDto dto)
        {
            TEntity entity=_mapper.Map<TEntity>(dto);
            return _repo.Update(entity);
        }

        public IEnumerable<TDto> GetByUserRequestList(int userId)
        {
            var entities = _repo.GetByUserRequestList(userId);
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}
