using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.BLL.Services
{
   public interface IBaseUserService<TDto> where TDto : class
    {
        ActionResponse<IQueryable<TDto>> GetAll(params Status[] statuses);
        ActionResponse<TDto> GetById(Guid id);
        ActionResponse Remove(Guid id);
        ActionResponse Save(TDto obj);

    }

}
