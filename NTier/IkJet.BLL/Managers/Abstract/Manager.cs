using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using IkJet.DAL.Services.Abstract;
using IkJet.DTO.Abstract;
using IkJet.Entities.Abstract;
using IkJet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.BLL.Managers.Abstract
{
    public abstract class Manager<TDto, TViewModel, TEntity> : IManager<TDto, TViewModel>
        where TViewModel : BaseViewModel
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected Service<TEntity, TDto> _service;
        protected IMapper _mapper;

        protected Manager(Service<TEntity, TDto> service)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.CreateMap<TDto, TViewModel>().ReverseMap();
            });
            _mapper = _config.CreateMapper();
            _service = service;
        }

        public IMapper Mapper
        {
            set { _mapper = value; }
        }

        public int Add(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);
            return _service.Add(dto);

        }

        public int Update(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);
            return _service.Update(dto);
        }

        public int Delete(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);
            return _service.Delete(dto);
        }

        public int Delete(int id)
        {
            return _service.Delete(id);
        }
        public int Remove(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);
            return _service.Remove(dto);
        }

        public TViewModel? Get(int id)
        {
            TDto? dto = _service.Get(id);
            return _mapper.Map<TViewModel>(dto);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            IEnumerable<TDto> list = _service.GetAll().ToList();

            return _mapper.Map<IEnumerable<TViewModel>>(list);

        }


        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            
            IEnumerable<TDto> list = await _service.GetAllAsync();

            
            return _mapper.Map<IEnumerable<TViewModel>>(list);
        }




        public IEnumerable<TViewModel> GetByUserRequestList(int userId)
        {
            var dtos = _service.GetByUserRequestList(userId);
            return _mapper.Map<IEnumerable<TViewModel>>(dtos);
        }
    }
}
