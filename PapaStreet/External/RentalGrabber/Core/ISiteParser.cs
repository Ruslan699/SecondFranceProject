using System.Threading.Tasks;
using AngleSharp.Dom;

namespace SiteGrabber.Core
{
    public interface ISiteParser
    {
        GenericAnnouncementModel ParseAnnouncement(IElement apart);
        Task Start();
        event OnNewAnnouncementParsed AnnouncementParsed;
    }
}