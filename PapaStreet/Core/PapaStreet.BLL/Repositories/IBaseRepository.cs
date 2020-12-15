using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.Repositories
{
    public interface IBaseRepository<TDto> where TDto : BaseDto
    {
        ActionResponse<IQueryable<TDto>> GetAll(params Status[] statuses);
        ActionResponse<TDto> GetById(Guid id);
        ActionResponse Remove(Guid id, Guid? userId = null);
        ActionResponse Save(TDto obj, Guid? userId = null);
    }
}
