using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using SiteGrabber.Core;

namespace SiteGrabber.Seloger
{
    public class SelogerParser:ISiteParser
    {
        private SelogerParser()
        {
            
        }

        public static SelogerParser Instance { get; } = new SelogerParser();
        public GenericAnnouncementModel ParseAnnouncement(IElement item)
        {
            GenericAnnouncementModel model =new GenericAnnouncementModel("seloger");
            model.LinkUrl = item.QuerySelector("div.c-pa-info > a")?.Attributes["href"]?.Value;
            if (string.IsNullOrEmpty(model.LinkUrl))
            {
                model.LinkUrl = item
                    .QuerySelector(
                        "div.c-pa-pic  div.slideContent > a")
                    ?.Attributes["href"]?.Value;
            }
            model.LinkText = item.QuerySelector("div.c-pa-info > a")?.TextContent;
            var Parameters = item.QuerySelectorAll("div.c-pa-info > div.c-pa-criterion em")?
                .Select(i => i?.TextContent).ToArray();

            model.Price = ((item
                               .QuerySelectorAll("div.c-pa-info > div.c-pa-price span")?
                               .Select(d => d.TextContent)
                               .Select(d => d.Replace("|", ""))) ?? new string[0])
                .Where(d => !string.IsNullOrEmpty(d)).ToList();

            model.Title = item.QuerySelector("div.c-pa-info > div.c-pa-loan > a")?.TextContent;
            model.City = item.QuerySelector("div.c-pa-info > div.c-pa-city")?.TextContent;
            model.Images = item
                .QuerySelectorAll(" div.c-pa-pic > div.c-pa-visual >div.c-pa-imgs >div.slideContent > a>div")?
                .Select(div => div?.Attributes["data-lazy"]?.Value?.ParseJson()?.SelectToken("url").ToString())
                .ToList();

            var AgencyLogoUrl = item.QuerySelectorAll("div.c-pa-info > div.c-pa-agency>a>div")?
                .Select(div =>
                    div?.Attributes["data-lazy"]?.Value.ParseJson()?.SelectToken("url").ToString())
                .FirstOrDefault();
            var AgencyName = item.QuerySelectorAll("div.c-pa-info > div.c-pa-agency>a>div")?
                .Select(div =>
                    div?.Attributes["alt"]?.Value)
                .FirstOrDefault();

            model.ID = item?.Attributes["data-listing-id"]?.Value;
            var PublicationId = item?.Attributes["data-publication-id"]?.Value;
            model.Extra = new {Parameters, AgencyLogoUrl, AgencyName, PublicationId};
            return model;
        }

        

        public async Task Start()
        {
            string templateUrl =
                "https://www.seloger.com/list.htm?tri=initial&idtypebien=2,1&pxMax=1000000&div=2238&idtt=2,5&naturebien=1,2,4";

            templateUrl =
                "https://www.seloger.com/list.htm?tri=initial&idtypebien=2,1&pxMax=100000000&div=2238&idtt=2,5&naturebien=1,2,4";

            templateUrl =
                "https://www.seloger.com/list.htm?tri=initial&idtypebien=2,1&idtt=2,5&naturebien=1,2,4&idPays=250";

            int i = 1;
            while (true)
            {
                Logger.WriteLine("\nloading seloger page: " + i);
                var url = templateUrl + "&LISTING-LISTpg=" + i;
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(url);
                var html = document.ToHtml();
                if (html.Contains("Aucun résultat pour l'instant"))
                {
                    Logger.WriteLine("seloger completed");
                    return;
                }

                if (html.Contains("Oops, une erreur technique est survenue. Merci de ressayer ultérieurement."))
                {
                    //error cixib
                    Logger.WriteLine("Seloger Server down waiting for 10 sec");
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    i++;
                    continue;                 
                }
                var listResult = document.QuerySelector("section.liste_resultat");
                if (listResult == null)
                {
                    i++;
                    continue;
                }
                var items = listResult.QuerySelectorAll(".c-pa-list")?.ToArray();
                if (items == null)
                {
                    i++;
                    continue;
                }
                foreach (var item in items)
                {
                    var model = ParseAnnouncement(item);
                    AnnouncementParsed?.Invoke(model);
                }
                i++;
            }
        }

        public event OnNewAnnouncementParsed AnnouncementParsed;
    }
}