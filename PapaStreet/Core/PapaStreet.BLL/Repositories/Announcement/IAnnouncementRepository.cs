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
    public interface IAnnouncementRepository : IBaseRepository<AnnouncementDto>
    {
        ActionResponse IncViewsCount(Guid id);
        ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Status[] statuses);
    }
}
