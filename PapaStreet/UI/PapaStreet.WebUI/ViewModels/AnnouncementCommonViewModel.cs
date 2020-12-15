using PapaStreet.BLL.DTOs;
using PapaStreet.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapaStreet.WebUI.ViewModels
{
    public class AnnouncementCommonViewModel
    {
        public IEnumerable<AnnouncementModel> Announcements { get; set; }
        public IEnumerable<AnnouncementModel> AllAnnouncements { get; set; }
        public IEnumerable<CityModel> Cities { get; set; }
        public IQueryable<Tuple<string, int>> TopCities { get; set; }
        public IEnumerable<PropertyTypeModel> PropertyTypes { get; set; }
        public IEnumerable<AnnouncementTypeModel> AnnouncementTypes { get; set; }
        public IEnumerable<DocumentTypeModel> DocumentTypes { get; set; }
        public IEnumerable<RepairModel> Repairs { get; set; }
        public IEnumerable<GenericAnnouncementDto> GenericAnnouncements { get; set; }
        public IEnumerable<RegionModel> Regions { get; set; }
        public IEnumerable<DepartamentModel> Departaments { get; set; }
        public IEnumerable<AnnouncementAdditionalModel> AnnouncementAdditionals { get; set; }
        public Pager Pager  { get; set; }
    }
}