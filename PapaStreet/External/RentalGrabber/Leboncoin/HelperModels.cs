using System.Collections.Generic;
using System.Linq;
using SiteGrabber.Core;

namespace SiteGrabber.Leboncoin
{
    #region inner classes

    public class Images
    {
        public string thumb_url { get; set; }
        public string small_url { get; set; }
        public int nb_images { get; set; }
        public List<string> urls { get; set; }
        public List<string> urls_thumb { get; set; }
        public List<string> urls_large { get; set; }
    }

    public class Attribute
    {
        public string key { get; set; }
        public string value { get; set; }
        public string value_label { get; set; }
        public bool generic { get; set; }
    }

    public class Location
    {
        public string region_id { get; set; }
        public string region_name { get; set; }
        public string department_id { get; set; }
        public string department_name { get; set; }
        public string city_label { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string source { get; set; }
        public string provider { get; set; }
        public bool is_shape { get; set; }
    }

    public class Owner
    {
        public string store_id { get; set; }
        public string user_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool no_salesmen { get; set; }
    }

    public class Options
    {
        public bool has_option { get; set; }
        public bool booster { get; set; }
        public bool photosup { get; set; }
        public bool urgent { get; set; }
        public bool gallery { get; set; }
        public bool sub_toplist { get; set; }
    }

    public class LeboncoinModelInner
    {
        public int list_id { get; set; }
        public string first_publication_date { get; set; }
        public string expiration_date { get; set; }
        public string index_date { get; set; }
        public string status { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string ad_type { get; set; }
        public string url { get; set; }
        public List<string> price{ get; set; }
        public object price_calendar { get; set; }
        public Images images { get; set; }
        public List<Attribute> attributes { get; set; }
        public Location location { get; set; }
        public Owner owner { get; set; }
        public Options options { get; set; }
        public bool has_phone { get; set; }

        public GenericAnnouncementModel ToGeneric()
        {
            var model=new GenericAnnouncementModel("leboncoin");
            model.ID = this.list_id.ToString();
            model.first_publication_date = first_publication_date;
            model.expiration_date = expiration_date;
            model.category_id = category_id;
            model.category_name = category_name;
            model.Title = subject;
            model.Description = body;
            model.LinkUrl = url;
            model.Owner = this.owner?.name;
            model.Price = this.price;
            model.SmallImages = new List<string>{ this.images?.small_url };
            model.ThumbImages = new List<string> { this.images?.thumb_url};
            if (this.images?.urls_thumb != null)
                model.ThumbImages.AddRange(this.images.urls_thumb);

            model.LargeUrls = this.images?.urls_large?.ToList();
            model.Latitude = this.location?.lat;
            model.Langitude = this.location?.lng;
            model.City = this.location?.city;
            model.Region = this.location?.region_name;
            model.Extra = new { index_date,status, ad_type, price_calendar, options, has_phone, attributes };
            return model;
        }
    }

    #endregion

}