using AutoMapper;
using IkJet.DTO.Abstract;
using IkJet.DTO.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkJet.DAL.Services.Abstract
{
    public interface IService<TDto> where TDto : BaseDto
    {
        IMapper Mapper { set; }
        int Add(TDto dto);
        int Update(TDto dto);
        int Delete(TDto dto);
        int Remove(TDto dto);
        int Delete(int id);
        IEnumerable<TDto> GetAll();
        TDto? Get(int id);
        IEnumerable<TDto> GetByUserRequestList(int userId);
    }
}
