using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.Repositories
{
    public class AnnouncementAdditionRepository : BaseRepository<AnnouncementAdditionDto, AnnouncementAdditionDao, MainDataContext>, IAnnouncementAdditionRepository
    {
    }
}
