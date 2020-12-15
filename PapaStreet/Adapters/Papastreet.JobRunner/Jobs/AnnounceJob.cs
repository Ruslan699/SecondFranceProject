using Microsoft.Practices.ServiceLocation;
using PapaStreet.BLL.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace Papastreet.JobRunner.Jobs
{
    [DisallowConcurrentExecution]
    public class AnnounceJob : IJob
    {
        private readonly AnnouncementService _announcementService;
        public AnnounceJob()
        {
            _announcementService = ServiceLocator.Current.GetInstance<AnnouncementService>();
        }
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var announcements = _announcementService.GetAll(Status.Active);
                if (announcements.IsSucceed)
                {
                    var dateFilter = DateTime.UtcNow.AddHours(4);
                    var expiredAnnouncements = announcements.Data
                        .Where(e => e.ExpirationDate < dateFilter).ToList();
                    foreach (var announcement in expiredAnnouncements)
                    {
                        announcement.Status = Status.Deactive;
                        _announcementService.Save(announcement);
                    }
                }
            }
            catch (Exception ex)
            {

            }
          
        }
    }
}
