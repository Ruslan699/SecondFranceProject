using AutoMapper;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.ServiceFacades;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly GenericAnnouncementServiceFacade _genericAnnouncementServiceFacade;
        private readonly AnnouncementServiceFacade _announcementServiceFacade;
        private readonly AnnouncementTypeServiceFacade _announcementTypeServiceFacade;
        private readonly PropertyTypeServiceFacade _propertyTypeServiceFacade;
        private readonly DocumentTypeServiceFacade _documentTypeServiceFacade;
        private readonly RepairServiceFacade _repairServiceFacade;
        private readonly CityServiceFacade _cityServiceFacade;
        private readonly RegionServiceFacade _regionServiceFacade;
        private readonly RegionDepartamentServiceFacade _regionDepartamentServiceFacade;
        private readonly DepartamentServiceFacade _departamentServiceFacade;
        private readonly DepartamentCityServiceFacade _departamentCityServiceFacade;

        public HomeController(AnnouncementServiceFacade announcementServiceFacade,
            GenericAnnouncementServiceFacade genericAnnouncementServiceFacade,
            AnnouncementTypeServiceFacade announcementTypeServiceFacade,
            PropertyTypeServiceFacade propertyTypeServiceFacade,
            DocumentTypeServiceFacade documentTypeServiceFacade,
            RepairServiceFacade repairServiceFacade,
            CityServiceFacade cityServiceFacade,
            RegionServiceFacade regionServiceFacade,
            RegionDepartamentServiceFacade regionDepartamentServiceFacade,
            DepartamentServiceFacade departamentServiceFacade,
            DepartamentCityServiceFacade departamentCityServiceFacade
            )
        {
            _announcementServiceFacade = announcementServiceFacade;
            _genericAnnouncementServiceFacade = genericAnnouncementServiceFacade;
            _announcementTypeServiceFacade = announcementTypeServiceFacade;
            _propertyTypeServiceFacade = propertyTypeServiceFacade;
            _documentTypeServiceFacade = documentTypeServiceFacade;
            _repairServiceFacade = repairServiceFacade;
            _cityServiceFacade = cityServiceFacade;
            _regionServiceFacade = regionServiceFacade;
            _regionDepartamentServiceFacade = regionDepartamentServiceFacade;
            _departamentServiceFacade = departamentServiceFacade;
            _departamentCityServiceFacade = departamentCityServiceFacade;
        }


        LesAgencesService.PropertyServiceClient propertyClient = new LesAgencesService.PropertyServiceClient();

        [HttpGet]
        public ActionResult Index(int? page, int? sortBy)
        {
            var propertyService = propertyClient.GetPropertyList().ToList();
            ViewBag.LesAgencesProperties = propertyService;
            int announceCount = _announcementServiceFacade.GetAll(Status.Active).Count();
            var pager = new Pager(announceCount, null, 9);
            var listdto = _announcementServiceFacade.PagerSortBy(sortBy, pager.CurrentPage, 9);

            var announcements = Mapper.Map<IEnumerable<AnnouncementModel>>(listdto);
            var modelAll = new AnnouncementCommonViewModel()
            {
                Cities = Mapper.Map<IEnumerable<CityModel>>(_cityServiceFacade.GetAll(Status.Active).OrderBy(e=>e.Name)),
                Announcements = announcements,
                AllAnnouncements = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active)),
                GenericAnnouncements = _genericAnnouncementServiceFacade.GetAll(Status.Active),
                TopCities = _announcementServiceFacade.GetTopCities().ToList().AsQueryable(),
                PropertyTypes = Mapper.Map<IEnumerable<PropertyTypeModel>>(_propertyTypeServiceFacade.GetAll(Status.Active)),
                AnnouncementTypes = Mapper.Map<IEnumerable<AnnouncementTypeModel>>(_announcementTypeServiceFacade.GetAll(Status.Active)),
                Departaments = Mapper.Map<IEnumerable<DepartamentModel>>(_departamentServiceFacade.GetAll(Status.Active).OrderBy(e=>e.Name)),
                Pager = pager
            };
            return View(modelAll);
        }

        [HttpPost]
        public ActionResult PagerSortBy(int? page, int? sortBy)
        {
            int announceCount = _announcementServiceFacade.GetAll(Status.Active).Count();
            var pager = new Pager(announceCount, page, 9);
            var listdto = _announcementServiceFacade.PagerSortBy(sortBy, pager.CurrentPage, 9);

            var announcements = Mapper.Map<IEnumerable<AnnouncementModel>>(listdto);
            var modelAll = new AnnouncementCommonViewModel()
            {
                Announcements = announcements,
                Pager = pager
            };

            return PartialView("Partials/AnnouncementViewPartials/_AnnouncementPartial", modelAll);
        }

        [HttpPost]
        public ActionResult Departaments(Guid? regionId)
        {
            List<CityDropDownViewModel> Cities = new List<CityDropDownViewModel>();
            List<DepartamentDropDownViewModel> Departaments = new List<DepartamentDropDownViewModel>();
            if (regionId != null)
            {
                var departaments = _regionDepartamentServiceFacade.GetAll(Status.Active)
                .Where(x => x.RegionId == regionId)
                .Select(e => new DepartamentDropDownViewModel()
                {
                    Text = e.Departament.Name,
                    Value = e.DepartamentId.ToString()
                }).ToList();
                Departaments.AddRange(departaments);

                foreach (var item in departaments)
                {
                    var dpId = Guid.Parse(item.Value);
                    var citiess = _departamentCityServiceFacade.GetAll(Status.Active)
                    .Where(x => x.DepartamentId== dpId)
                    .Select(e => new CityDropDownViewModel()
                    {
                        Text = e.City.Name,
                        Value = e.CityId.ToString()
                    }).ToList();
                    Cities.AddRange(citiess);
                }

                var model = new DepartamentCityViewModel()
                {
                    Departaments = Departaments,
                    Cities = Cities

                };
                return Json(model);
            }
            else
            {
                var departaments = _regionDepartamentServiceFacade.GetAll(Status.Active)
                .Select(e => new DepartamentDropDownViewModel()
                {
                    Text = e.Departament.Name,
                    Value = e.DepartamentId.ToString()
                }).ToList();
                Departaments.AddRange(departaments);

                var citiess = _cityServiceFacade.GetAll(Status.Active)
                .Select(e => new CityDropDownViewModel()
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }).ToList();
                Cities.AddRange(citiess);

                var modelAll = new DepartamentCityViewModel()
                {
                    Departaments = Departaments,
                    Cities = Cities
                };
                return Json(modelAll);
            }
             
        }

        [HttpPost]
        public ActionResult Cities(Guid? departamentId)
        {
            if (departamentId != null)
            {
                var cities = _departamentCityServiceFacade.GetAll(Status.Active)
                .Where(x => x.DepartamentId == departamentId)
                .Select(e => new SelectListItem()
                {
                    Text = e.City.Name,
                    Value = e.CityId.ToString()
                }).ToList();

                return Json(cities);
            }
            else
            {
                var cities = _cityServiceFacade.GetAll(Status.Active)
                .Select(e => new SelectListItem()
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }).ToList();

                return Json(cities);
            }
        }

        #region GetPropertyImage
        [HttpGet]
        [OutputCache(Duration = 86400, VaryByParam = "id")]
        public async Task<ActionResult> GetPropertyImage(Guid id)
        {
            var propertyService = propertyClient.GetPropertyDocument(id);
            var imageStr = propertyService.Image;
            return File(imageStr, "image/gif");
        }
        #endregion

    }
}