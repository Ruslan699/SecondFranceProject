using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using SiteGrabber.Core;

namespace SiteGrabber.SuperImmo
{
    public class SuperImmoParser: ISiteParser
    {
        public static SuperImmoParser Instance { get; } = new SuperImmoParser();

        public event OnNewAnnouncementParsed AnnouncementParsed;


        private SuperImmoParser()
        {
            
        }
        public GenericAnnouncementModel ParseAnnouncement(IElement apart)
        {
            GenericAnnouncementModel model = new GenericAnnouncementModel("superimmo");

            model.first_publication_date = apart.QuerySelector(" section > div.media-left > div:nth-child(1) > b")
                ?.Attributes["data-created-at"]?.Value;

            model.ID = apart.QuerySelector(" section > div.media-left > div:nth-child(1) > b")
                ?.Attributes["data-listing-id"]?.Value;

            var NBR = apart.QuerySelector("section > div.media-left > div:nth-child(1) > span")
                ?.TextContent;

            model.Images = apart
                .QuerySelectorAll("section > div.media-left > div:nth-child(1) img")
                .Select(img => img?.Attributes["src"]?.Value)
                .Where(u => !string.IsNullOrEmpty(u))
                .Distinct()
                .ToList();

            model.SmallImages = new List<string>
            {
                apart.QuerySelector("section > div.media-left > div.media > div.media-left > img")?.Attributes["src"]
                    ?.Value
            };

            model.LinkText = apart.QuerySelector("section > div.media-left > div.media > div.media-body > small")
                ?.TextContent;
            model.Price = new List<string>() {null};
            model.Price[0] = apart.QuerySelector("section > div.media-body > p > a > b.prix")?.TextContent;
            var PricePerSquare = apart.QuerySelector(" section > div.media-body > p > a > small")?.TextContent;

            model.Title = apart
                .QuerySelector(
                    "section > div.media-body > p > a > b.titre")
                ?.TextContent;

            var Text1 = apart
                .QuerySelector(
                    " section > div.media-body > p > a")
                ?.TextContent;

            var Text2 = apart
                .QuerySelector(
                    "section > div.media-body > b")
                ?.TextContent;

            model.Description = apart.QuerySelector("section > div.media-body > div > p")
                ?.TextContent;

            model.Extra = new {Text1, Text2, PricePerSquare, NBR};
            return model;
        }


        public   async Task Start()
        {
            var config = Configuration.Default.WithDefaultLoader();
            const string baseAddress = "https://www.superimmo.com/achat/aquitaine/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(baseAddress);


            var aSelectors = "ul.pagination li.large-sm a";
            var apartsSelector = "article.appart_view";

            var cells = document.QuerySelectorAll(aSelectors);
            int pageCount;
            int.TryParse(cells?.Last()?.TextContent, out pageCount);

            var aparts = document.QuerySelectorAll(apartsSelector).ToArray();

            foreach (IElement apart in aparts)
            {
                AnnouncementParsed?.Invoke(ParseAnnouncement(apart));
            }

            for (int i = 2; i <= pageCount; i++)
            {
                Logger.WriteLine("loading superimmo on page " + i + "/" + pageCount);
                var url = baseAddress + "p/" + i;
                context = BrowsingContext.New(config);
                document = await context.OpenAsync(url);
                aparts = document.QuerySelectorAll(apartsSelector).ToArray();

                foreach (IElement apart in aparts)
                {
                    AnnouncementParsed?.Invoke(ParseAnnouncement(apart));
                }
            }
            Logger.WriteLine("superimmo completed");
            //var titles = cells.Select(m => m.TextContent);
        }
    }
}