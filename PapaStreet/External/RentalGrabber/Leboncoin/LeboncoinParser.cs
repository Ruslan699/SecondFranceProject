using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiteGrabber.Core;

namespace SiteGrabber.Leboncoin
{
    public class LeboncoinParser:ISiteParser
    {
        public static LeboncoinParser Instance { get; } = new LeboncoinParser();
        public event OnNewAnnouncementParsed AnnouncementParsed;

        private IHtmlDocument DownloadHTML(string url)
        {
            using (var client = new GZipWebClient())
            {
                client.Headers["User-Agent"] =
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.121 Safari/537.36";
                client.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                client.Headers["Accept-Encoding"] = "gzip, deflate, br";
                client.Headers["Accept-Language"] = "en-US,en;q=0.9,az;q=0.8,ru;q=0.7";
                //client.Headers["Connection"] = "keep-alive";
                client.Headers["Cache-Control"] = "no-cache";
                client.Headers["Pragma"] = "no-cache";
                client.Headers["Host"] = "www.leboncoin.fr";
                client.Headers["Upgrade-Insecure-Requests"] = "1";


                var html = client.DownloadString(url);
                var parser = new HtmlParser();
                var document = parser.ParseDocument(html);
                return document;
            }
        }

        public IEnumerable<string> GetRegions()
        {
            var urlBase = "https://www.leboncoin.fr/";
            var document = DownloadHTML(urlBase);
            var regions = document.QuerySelectorAll("svg a.trackable")?.Select(a => a?.Attributes["href"]?.Value)
                .ToArray();
            if (regions != null)
                foreach (var region in regions)
                {
                    yield return urlBase + region;
                }
        }

        public GenericAnnouncementModel ParseAnnouncement(IElement apart)
        {
            throw new NotImplementedException();
        }

        public Task Start()
        {
            var regionsLength = GetRegions().Count();
            for (int i = 1; i <=regionsLength; i++)
            {
                var all = ParseAll(i);
                var dict = new List<string>();
                foreach (GenericAnnouncementModel  modelEx in all)
                {
                    if (dict.Contains(modelEx.ID))
                    {
                        break;
                    }
                    dict.Add(modelEx.ID);
                    AnnouncementParsed?.Invoke(modelEx);
                }
            }

            Logger.WriteLine("Leboncoin completed");
            return Task.CompletedTask;
        }


        //public async Task Start_Old()
        //{
        //    var regions = GetRegions();
        //    foreach (var region in regions)
        //    {
        //        //await AnalyzeRegion(region);
        //        await AnalyzeRegionEx(region);
        //        ////GetRegionData()
        //        //var all = ParseAll(7);
        //        //var t = 0;
        //        //var dict = new List<int>();
        //        //foreach (LeboncoinModelEx modelEx in all)
        //        //{
        //        //    if (dict.Contains(modelEx.list_id))
        //        //    {
        //        //        break;
        //        //    }
        //        //    dict.Add(modelEx.list_id);
        //        //    Logger.WriteLine("" + t++ + ") " + modelEx.list_id + " ");
        //        //}
        //    }
        //}

        //private async Task AnalyzeRegion(string region)
        //{
        //    int i = 1;
        //    while (true)
        //    {
        //        var url = $"{region}/p-{i}/".Replace("//", "/").Replace(":/","://");
        //        var document = DownloadHTML(url);
        //        var scriptLine = document.ToHtml().Split("\r\t\n".ToCharArray()).FirstOrDefault(s=>s.Contains("window.FLUX_STATE"));
        //        scriptLine = scriptLine.Replace("window.FLUX_STATE = ", "");
        //        var obj = JObject.Parse(scriptLine);
        //        //var byId1 = obj["lbcData"]["categories"]["byId"];
        //        var fileName = i + "__" + region.Replace("/", "").Replace("https:", "") + ".json";
        //        File.WriteAllText(fileName, scriptLine);
        //        Logger.Write("  loaded "+i+"\t");
        //        Console.CursorLeft = 0;
        //        i++;
        //        //var byId = JObject.Parse(byId1.ToString()).Children();//.Select(s => s.Value).ToArray();
        //        //var categories = byId.Cast<JProperty>().Select(c=>c.Value)
        //        //    .Select((c) => new
        //        //{
        //        //    Id = c["id"].ToString(), Channel = c["channel"].ToString(), Label = c["label"].ToString(),
        //        //    Name = c["name"].ToString()
        //        //}).ToArray();




        //        //var query = "div#application div.bgMain > div ul>li[data-qa-id=\"aditem_container\"] ";
        //        //var listItems = document.QuerySelectorAll(query);
        //        //foreach (var item in listItems)
        //        //{
        //        //    var model = ParseLebonCoinModel(item);
        //        //    int ed = 12;
        //        //}
        //        int a = 1;
        //    }
        //}
        //private async Task AnalyzeRegionEx(string region)
        //{
        //    int i = 1;
        //    while (true)
        //    {
        //        var url = $"{region}/p-{i}/".Replace("//", "/").Replace(":/", "://");
        //        var document = DownloadHTML(url);
        //        var list = document.QuerySelectorAll("ul > li[itemscope]");
        //        foreach (var element in list)
        //        {
        //            var itemProps=element.QuerySelectorAll("[itemprop]");
        //            var dict = itemProps.Select(e => e.Attributes.Select(ass => new {ass.Name, ass.Value}).ToArray())
        //                .ToArray();
        //        }
        //        int a = 1;
        //    }
        //}
        //private GenericAnnouncementModel ParseLebonCoinModel(IElement item)
        //{
        //    GenericAnnouncementModel model =new GenericAnnouncementModel();
        //    model.Title = item.QuerySelector("span[data-qa-id='aditem_title']")?.TextContent;
        //    model.Price = item.QuerySelector("span[itemprop='priceCurrency']")?.InnerHtml;
           
        //    model.PriceCurrency = item.QuerySelector("span[itemprop='priceCurrency']")?.Attributes["content"]?.Value;
        //    model.AlternateName = item.QuerySelector("p[itemprop='alternateName']")?.TextContent;
        //    model.AvailableAtOrFrom = item.QuerySelector("p[itemprop='availableAtOrFrom']")?.TextContent;
        //    model.AvailabilityStarts = item.QuerySelector("p[itemprop='availabilityStarts']")?.TextContent;
        //    model.Images = item.QuerySelectorAll("div.LazyLoad img")?.Select(img => img?.Attributes["src"]?.Value)
        //        .ToArray();
                
        //    return model;
        //}

        public static async Task<GenericAnnouncementModel[]> GetRegionData(int regionId, int offset = 0)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.leboncoin.fr/finder/search"))
                {
                    request.Headers.TryAddWithoutValidation("Referer", "https://www.leboncoin.fr/annonces/offres/centre/");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("Origin", "https://www.leboncoin.fr");
                    request.Headers.TryAddWithoutValidation("api_key", "ba0c2dad52b3ec");

                    //request.Content = new StringContent("{\"limit\":35,\"limit_alu\":3,\"filters\":{\"category\":{},\"enums\":{\"ad_type\":[\"offer\"]},\"location\":{\"locations\":[{\"locationType\":\"region\",\"label\":\"Centre\",\"region_id\":\"7\"}]},\"keywords\":{},\"ranges\":{}}}", Encoding.UTF8, "text/plain");

                    request.Content = new StringContent(
                        $"{{\"limit\":100,\"limit_alu\":0,\"offset\":{offset},\"filters\":{{\"category\":{{}},\"enums\":{{}},\"location\":{{\"locations\":[{{\"locationType\":\"region\",\"label\":\"Centre\",\"region_id\":\"{regionId}\"}}]}},\"keywords\":{{}},\"ranges\":{{}}}}}}",
                        Encoding.UTF8, "text/plain");

                    var response = await httpClient.SendAsync(request);
                    var ms = new MemoryStream();
                    await response.Content.CopyToAsync(ms);
                    var data = ms.ToArray();
                    var json = Encoding.UTF8.GetString(data);
                    var obj = JObject.Parse(json);
                    var list = obj["ads"];
                    var result = new List<GenericAnnouncementModel>();
                    foreach ( var element in list)
                    {
                        var jsonInner = element.ToString();
                        var model = JsonConvert.DeserializeObject<LeboncoinModelInner>(jsonInner);
                        if (model != null)
                        {
                            result.Add(model.ToGeneric());
                        }
                        else
                        {
                            Logger.Write("model null geldi");
                        }
                    }

                    return result.ToArray();
                }
            }
        }


        public static IEnumerable<GenericAnnouncementModel> ParseAll(int regionId)
        {
            int offset = 0;
            while (true)
            {
                var task = GetRegionData(regionId, offset);
                task.Wait();
                var data = task.Result;
                var exit = true;
                foreach (var modelEx in data)
                {
                    yield return modelEx;
                    exit = false;
                }
                offset += 100;
                if (exit) break;
            }
        }
    }
}