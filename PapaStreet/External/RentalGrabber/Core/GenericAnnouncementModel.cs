using System.Collections.Generic;

namespace SiteGrabber.Core
{
    public class GenericAnnouncementModel
    {
        public string HostSite{ get; set; }
        public GenericAnnouncementModel(string hostSite)
        {
            HostSite = hostSite;
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public List<string> Images { get; set; }

        public List<string> ThumbImages { get; set; }
        public List<string> SmallImages { get; set; }
        public List<string> LargeUrls { get; set; }

        public  List<string> Price { get; set; }
        public string first_publication_date { get; set; }
        public string expiration_date { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string LinkUrl { get; set; }
        public object Extra { get; set; }
        public string LinkText { get; set; }
        public string City { get; set; }
        public double? Latitude { get; set; }
        public double? Langitude { get; set; }
        public string Region { get; set; }

        public string GenerateQuery()
        {
            var query = $@" 
IF(NOT EXISTS(SELECT TOP (1) 1 from [dbo].[GenericAnnouncements] where ExternalId={ID.Safe()} ))
BEGIN
    INSERT INTO [dbo].[GenericAnnouncements]
               ([Id]
               ,[ExternalId]
               ,[HostSite]
               ,[Title]
               ,[Description]
               ,[Owner]
               ,[Images]
               ,[ThumbImages]
               ,[SmallImages]
               ,[LargeUrls]
               ,[Price]
               ,[First_Publication_Date]
               ,[Expiration_Date]
               ,[Category_Id]
               ,[Category_Name]
               ,[LinkUrl]
               ,[Extra]
               ,[LinkText]
               ,[City]
               ,[Latitude]
               ,[Langitude]
               ,[Region]
               ,[SourceType])
         VALUES
               (NEWID()
               ,{ID.Safe()}
               ,{HostSite.Safe()}
               ,{Title.Safe()}
               ,{Description.Safe()}
               ,{Owner.Safe()}
               ,{Images.Safe()}
               ,{ThumbImages.Safe()}
               ,{SmallImages.Safe()}
               ,{LargeUrls.Safe()}
               ,{Price.Safe()}
               ,{first_publication_date.Safe()}
               ,{expiration_date.Safe()}
               ,{category_id.Safe()}
               ,{category_name.Safe()}
               ,{LinkUrl.Safe()}
               ,{Extra.Safe()}
               ,{LinkText.Safe()}
               ,{City.Safe()}
               ,{Latitude.Safe()}
               ,{Langitude.Safe()}
               ,{Region.Safe()}
               ,0)
END;
ELSE
BEGIN
    UPDATE [dbo].[GenericAnnouncements]
       SET 
           [HostSite] = {HostSite.Safe()}
          ,[Title] = {Title.Safe()}
          ,[Description] = {Description.Safe()}
          ,[Owner] = {Owner.Safe()}
          ,[Images] = {Images.Safe()}
          ,[ThumbImages] = {ThumbImages.Safe()}
          ,[SmallImages] = {SmallImages.Safe()}
          ,[LargeUrls] = {LargeUrls.Safe()}
          ,[Price] = {Price.Safe()}
          ,[First_Publication_Date] = {first_publication_date.Safe()}
          ,[Expiration_Date] = {expiration_date.Safe()}
          ,[Category_Id] = {category_id.Safe()}
          ,[Category_Name] = {category_name.Safe()}
          ,[LinkUrl] = {LinkUrl.Safe()}
          ,[Extra] = {Extra.Safe()}
          ,[LinkText] = {LinkText.Safe()}
          ,[City] = {City.Safe()}
          ,[Latitude] = {Latitude.Safe()}
          ,[Langitude] = {Langitude.Safe()}
          ,[Region] = {Region.Safe()}
          --,[SourceType] = <SourceType, int,>
     WHERE ExternalId={ID.Safe()}

END;
";


            return query;
        }
    }
}