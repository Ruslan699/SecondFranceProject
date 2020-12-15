using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.Repositories;
using PapaStreet.Common.Constants;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;

namespace PapaStreet.DAL.Repositories
{
    public class AnnouncementRepository : BaseRepository<AnnouncementDto,AnnouncementDao,MainDataContext>, IAnnouncementRepository
    {
        private MainDataContext ctx;
        public ActionResponse IncViewsCount(Guid id)
        {
            try
            {
                ctx = Activator.CreateInstance<MainDataContext>();
                var entity = ctx.Announcements.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                    return ActionResponse.Failure(UI.NotFound);
                entity.ViewsCount += 1;
                ctx.Entry<AnnouncementDao>(entity).State = EntityState.Modified;
                ctx.SaveChanges();
                return ActionResponse.Succeed();
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }

        public ActionResponse<IQueryable<Tuple<string, int>>> GetTopCities(params Enums.Status[] statuses)
        {
            try
            {
                ctx = Activator.CreateInstance<MainDataContext>();
                var data = ctx.Announcements.GroupBy(e => e.City.Name)
                    .Select(e => new { name = e.Key, count = e.Count() }).ToList()
                    .Select(e => Tuple.Create<string, int>(e.name, e.count))
                    .Where(e => e.Item2 > 4).AsQueryable();

                return ActionResponse<IQueryable<Tuple<string, int>>>.Succeed(data);
            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<Tuple<string, int>>>.Failure(ex.Message);
            }
        }
    }
}
