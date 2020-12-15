using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.Repositories
{
    public class PricePlanHistoryRepository : BaseRepository<PricePlanHistoryDto, PricePlanHistoryDao, MainDataContext>, IPricePlanHistoryRepository
    {
        private MainDataContext ctx;
        public ActionResponse DecUsedAnnouncementCount(Guid id)
        {
                try
                {
                    ctx = Activator.CreateInstance<MainDataContext>();
                    var entity = ctx.PricePlanHistories.FirstOrDefault(e => e.CustomerId == id);
                    if (entity == null)
                        return ActionResponse.Failure(UI.NotFound);
                    entity.UsedAnnouncementCount -= 1;
                    ctx.Entry<PricePlanHistoryDao>(entity).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return ActionResponse.Succeed();
                }
                catch (Exception ex)
                {
                    return ActionResponse.Failure(ex.Message);
                }
        }
    }
}
