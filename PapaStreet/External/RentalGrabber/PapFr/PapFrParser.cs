using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using SiteGrabber.Core;

namespace SiteGrabber.PapFr
{
    public class PapFrParser:ISiteParser
    {
        public static PapFrParser Instance { get; } = new PapFrParser();

        public event OnNewAnnouncementParsed AnnouncementParsed;

        private PapFrParser()
        {
            
        }
        public GenericAnnouncementModel ParseAnnouncement(IElement apart)
        {
            throw new System.NotImplementedException();
        }

        public async Task Start()
        {
            const int max = 25;
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("loading pap fr page " + i + 1);
                var baseAddress = "https://www.pap.fr/annonce/propriete-en-vente-ile-de-france-g471-" + i;
                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(baseAddress);
                var list = document.QuerySelectorAll(".main-content .search-results-list .search-list-item");
                foreach (var element in list)
                {
                    var model = new GenericAnnouncementModel("pap.fr");
                    var imgSrc = element.QuerySelector(" div.col-left > a > img")?.Attributes["src"]?.Value;
                    var url = element.QuerySelector(" div.col-left > a")?.Attributes["href"]?.Value;
                    var photoCount = element.QuerySelector(" div.col-left > .item-photo-count")?.Text();
                    if(!url.StartsWith("https://"))url = "https://www.pap.fr" + url;
                    var title = element.QuerySelector("div.col-right > a.item-title > span.h1")?.TextContent;
                    var itemTags = element.QuerySelectorAll("div.col-right > a.item-title > ul > li")?.Select(li => li?.TextContent).ToArray();
                    var itemPrice = element.QuerySelector(".col-right .item-price")?.TextContent;
                    var priceDescription = element.QuerySelector(".col-right .mensualite-prix")?.TextContent;
                    var itemDescription = element.QuerySelector(".col-right > p.item-description")?.TextContent;
                    var itemTransport = element.QuerySelector(".col-right > .item-transports")?.TextContent;
                    var id = url?.Split('/')?.Last();
                    //id = id?.Replace("r", "");
                    if (string.IsNullOrEmpty(id)) id = string.Empty;
                    if (id.Contains("?")) id = id.Split('?').First();
                    if (id.Contains("-")) id = id.Split('-').Last();

                    model.ID = id;
                    model.Images = new List<string> {imgSrc};
                    model.LinkUrl = url;
                    model.Title = title;
                    model.Price = new List<string>{ itemPrice };
                    model.Description = itemDescription;
                    model.Extra = new {photoCount, itemTags, priceDescription, itemTransport};

                    AnnouncementParsed?.Invoke(model);
                }
            }
        }

    }
}