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
    public interface IGenericAnnouncementRepository : IBaseRepository<GenericAnnouncementDto>
    {
        ActionResponse<IQueryable<GenericAnnouncementDto>> GetAll_Old(params Status[] statuses);
        ActionResponse<GenericAnnouncementDto> GetById(Guid id, params Status[] statuses);
        ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Status[] statuses);
        ActionResponse<IQueryable<GenericAnnouncementDto>> SearchPagerSortBy(SearchDto search, int currentPage, int pageSize, params Status[] statuses);
        ActionResponse<int> SearchPagerSortByCount(SearchDto search, params Status[] statuses);
    }
}
