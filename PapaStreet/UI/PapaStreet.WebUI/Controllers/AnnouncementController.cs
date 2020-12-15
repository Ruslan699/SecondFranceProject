using AutoMapper;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using PapaStreet.DAL.DataContexts;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.Security;
using PapaStreet.WebUI.ServiceFacades;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Controllers
{

    public class AnnouncementController : BaseController
    {
        private readonly AnnouncementServiceFacade _announcementServiceFacade;
        private readonly AnnouncementImageServiceFacade _announcementImageServiceFacade;
        private readonly AnnouncementTypeServiceFacade _announcementTypeServiceFacade;
        private readonly DocumentTypeServiceFacade _documentTypeServiceFacade;
        private readonly PropertyTypeServiceFacade _propertyTypeServiceFacade;
        private readonly RepairServiceFacade _repairServiceFacade;
        private readonly PhoneNumberServiceFacade _phoneNumberServiceFacade;
        private readonly CityServiceFacade _cityServiceFacade;
        private readonly CommonServiceFacade _commonServiceFacade;
        private readonly CustomerServiceFacade _customerServiceFacade;
        private readonly GenericAnnouncementServiceFacade _genericAnnouncementServiceFacade;
        private readonly RegionServiceFacade _regionServiceFacade;
        private readonly RegionDepartamentServiceFacade _regionDepartamentServiceFacade;
        private readonly DepartamentServiceFacade _departamentServiceFacade;
        private readonly DepartamentCityServiceFacade _departamentCityServiceFacade;
        private readonly PricePlanHistoryServiceFacade _pricePlanHistoryServiceFacade;
        private readonly AnnouncementAdditionServiceFacade _announcementAdditionServiceFacade;

        public AnnouncementController(AnnouncementServiceFacade announcementServiceFacade,
            AnnouncementTypeServiceFacade announcementTypeServiceFacade,
            AnnouncementImageServiceFacade announcementImageServiceFacade,
            DocumentTypeServiceFacade documentTypeServiceFacade,
            PropertyTypeServiceFacade propertyTypeServiceFacade,
            RepairServiceFacade repairServiceFacade,
            PhoneNumberServiceFacade phoneNumberServiceFacade,
            CityServiceFacade cityServiceFacade, CommonServiceFacade commonServiceFacade,
            CustomerServiceFacade customerServiceFacade,
            GenericAnnouncementServiceFacade genericAnnouncementServiceFacade,
            RegionServiceFacade regionServiceFacade,
            RegionDepartamentServiceFacade regionDepartamentServiceFacade,
            DepartamentServiceFacade departamentServiceFacade,
            DepartamentCityServiceFacade departamentCityServiceFacade,
            PricePlanHistoryServiceFacade pricePlanHistoryServiceFacade,
            AnnouncementAdditionServiceFacade announcementAdditionServiceFacade
            )
        {
            _announcementServiceFacade = announcementServiceFacade;
            _announcementTypeServiceFacade = announcementTypeServiceFacade;
            _announcementImageServiceFacade = announcementImageServiceFacade;
            _documentTypeServiceFacade = documentTypeServiceFacade;
            _propertyTypeServiceFacade = propertyTypeServiceFacade;
            _repairServiceFacade = repairServiceFacade;
            _phoneNumberServiceFacade = phoneNumberServiceFacade;
            _cityServiceFacade = cityServiceFacade;
            _commonServiceFacade = commonServiceFacade;
            _customerServiceFacade = customerServiceFacade;
            _genericAnnouncementServiceFacade = genericAnnouncementServiceFacade;
            _regionServiceFacade = regionServiceFacade;
            _regionDepartamentServiceFacade = regionDepartamentServiceFacade;
            _departamentServiceFacade = departamentServiceFacade;
            _departamentCityServiceFacade = departamentCityServiceFacade;
            _pricePlanHistoryServiceFacade = pricePlanHistoryServiceFacade;
            _announcementAdditionServiceFacade = announcementAdditionServiceFacade;
        }
        [HttpGet]
        public ActionResult Index(Search search)
        {
            if (search.Cities != null)
            {
                search.CityName = new List<string>();
                foreach (var item in search.Cities)
                {
                        search.CityName.Add(_cityServiceFacade.GetById(item.Value).Name);
                }
            }
            int announceCount = _announcementServiceFacade.SearchPagerSortByCount(search);
            int genericannounceCount = _genericAnnouncementServiceFacade.SearchPagerSortByCount(search);
            var pager = new Pager(announceCount + genericannounceCount, null, 9);
            var listdto = _announcementServiceFacade.SearchPagerSortBy(search, pager.CurrentPage, pager.PageSize);
            var listgenericdto = _genericAnnouncementServiceFacade.SearchPagerSortBy(search, pager.CurrentPage, pager.PageSize);

            var announcements = Mapper.Map<IEnumerable<AnnouncementModel>>(listdto);
            var modelAll = new AnnouncementCommonViewModel()
            {
                Cities = Mapper.Map<IEnumerable<CityModel>>(_cityServiceFacade.GetAll(Status.Active).OrderBy(e=>e.Name)),
                Announcements = announcements,
                AllAnnouncements = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active)),
                GenericAnnouncements = listgenericdto,
                PropertyTypes = Mapper.Map<IEnumerable<PropertyTypeModel>>(_propertyTypeServiceFacade.GetAll(Status.Active)),
                AnnouncementTypes = Mapper.Map<IEnumerable<AnnouncementTypeModel>>(_announcementTypeServiceFacade.GetAll(Status.Active)),
                Departaments = Mapper.Map<IEnumerable<DepartamentModel>>(_departamentServiceFacade.GetAll(Status.Active).OrderBy(e=>e.Name)),
                AnnouncementAdditionals = Mapper.Map<IEnumerable<AnnouncementAdditionalModel>>(_announcementAdditionServiceFacade.GetAll(Status.Active)),
                Pager = pager
            };
            return View(modelAll);
        }

        [HttpPost]
        public ActionResult Search(Search search)
        {
            if (search.Cities != null)
            {
                search.CityName = new List<string>();
                foreach (var item in search.Cities)
                {
                       search.CityName.Add(_cityServiceFacade.GetById(item.Value).Name);
                }
            }
            int announceCount = _announcementServiceFacade.SearchPagerSortByCount(search);
            int genericannounceCount = _genericAnnouncementServiceFacade.SearchPagerSortByCount(search);
            var pager = new Pager(announceCount + genericannounceCount, search.page, 9);
            var listdto = _announcementServiceFacade.SearchPagerSortBy(search, pager.CurrentPage, 9);
            var announcements = Mapper.Map<IEnumerable<AnnouncementModel>>(listdto);
            var listgenericdto = _genericAnnouncementServiceFacade.SearchPagerSortBy(search, pager.CurrentPage, 9);
            var modelAll = new AnnouncementCommonViewModel()
            {
                Announcements = announcements,
                GenericAnnouncements = listgenericdto,
                Pager = pager
            };
            

            return PartialView("Partials/AnnouncementPartials/_AnnouncementPartial", modelAll);
        }

        [AuthFilter]
        [Route("announce")]
        public ActionResult Announce()
        {
            ViewBag.Departaments = Mapper.Map<IEnumerable<DepartamentModel>>(_departamentServiceFacade.GetAll(Status.Active));
            ViewBag.Cities = _cityServiceFacade.GetAll(Status.Active);
            ViewBag.AnnouncementTypes = _announcementTypeServiceFacade.GetAll(Status.Active);
            ViewBag.PropertyTypes = _propertyTypeServiceFacade.GetAll(Status.Active);
            ViewBag.AnnouncementAdditionals = _announcementAdditionServiceFacade.GetAll(Status.Active);
            var model = new AnnouncementModel();
            if (Identity.IsAuthenticated)
                model.Email = Identity.Customer.Email;
            return View(model);
        }

        [AuthFilter]
        [Route("myannounce/{id}")]
        [HttpGet]
        public ActionResult MyAnnounce(Guid id, Status? status, int? page)

        {
            status = status ?? Status.Active;
            var dto = _customerServiceFacade.GetById(id);
            var all = _announcementServiceFacade.GetAll(status.Value).Where(x => x.Email == dto.Email);
            var t = all.ToList();
            var pager = new Pager(all.Count(), page, 5);
            ViewBag.Pager = pager;
            var listDto = _announcementServiceFacade.GetAll(pager.CurrentPage, pager.PageSize, dto.Email, status.Value);
            var model = Mapper.Map<IEnumerable<AnnouncementModel>>(listDto);
            return View(model);
        }

        [Route("items/{id}")]
        public ActionResult Items(Guid id)
        {
            var status = _announcementServiceFacade.GetById(id).Status;
            if (status != Status.Active)
                return RedirectToAction("Index", "Home");
            _announcementServiceFacade.IncViewsCount(id);
            var dto = _announcementServiceFacade.GetById(id, Status.Active);
            var model = Mapper.Map<AnnouncementModel>(dto);
            if (model.AnnouncementAddition != null)
            {
                List<string> AnnouncementAdditionals = new List<string>();
                foreach (var item in model.AnnouncementAddition.Split(','))
                {
                    var additionName = _announcementAdditionServiceFacade.GetById(Guid.Parse(item)).Name;
                    AnnouncementAdditionals.Add(additionName);
                }

                model.AnnouncementAdditionals = AnnouncementAdditionals;
            }
            ViewBag.LastAnnounces = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active).OrderByDescending(x => x.CreatedDate).Take(3));
            ViewBag.SimilarAnnounces = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active).Where(e => e.RoomCount == dto.RoomCount && e.Id != id)).Take(12);
            return View("AnnounceDetails", model);
        }

        [Route("item/{id}")]
        public ActionResult Item(Guid id)
        {
            var status = _genericAnnouncementServiceFacade.GetById(id).Status;
            if (status != Status.Active)
                return RedirectToAction("Index", "Home");
            var model = _genericAnnouncementServiceFacade.GetById(id, Status.Active);
            var dto = _announcementServiceFacade.GetById(id, Status.Active);
            ViewBag.LastAnnounces = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active).OrderByDescending(x => x.CreatedDate).Take(3));
            //ViewBag.SimilarAnnounces = Mapper.Map<IEnumerable<AnnouncementModel>>(_announcementServiceFacade.GetAll(Status.Active).Where(e => e.RoomCount == dto.RoomCount && e.Id != id)).Take(12);
            return View("OtherAnnounceDetails", model);
        }

        [HttpPost]
        public ActionResult Save(AnnouncementModel announcementModel, IEnumerable<HttpPostedFileBase> files)
        {
            int x = Request.Files.Count;
            var responsemain = new SiteResponse();
            var customer = _customerServiceFacade.GetAll(Status.Active).FirstOrDefault(c => c.Email == announcementModel.Email);

            if (customer != null)
            {
                var priceplanhistory = _pricePlanHistoryServiceFacade.GetAll(Status.Active).FirstOrDefault(p => p.CustomerId == customer.Id);
                if (priceplanhistory.UsedAnnouncementCount > 0)
                {
                    if(announcementModel.AnnouncementAdditionals!=null)
                    announcementModel.AnnouncementAddition = String.Join(",", announcementModel.AnnouncementAdditionals);
                    var dtoannounce = Mapper.Map<AnnouncementDto>(announcementModel);
                    if (files != null && files.Count() > 3)
                    {
                        var response = _announcementServiceFacade.Save(dtoannounce);
                        if (response.IsSucceed)
                        {
                            _pricePlanHistoryServiceFacade.DecUsedAnnouncementCount(customer.Id);

                            foreach (var file in files)
                            {
                                AnnouncementImageModel announcementImageModel = new AnnouncementImageModel();
                                announcementImageModel.AnnouncementId = dtoannounce.Id;
                                announcementImageModel.HttpPostedFileBase = file;
                                var dtoimage = Mapper.Map<AnnouncementImageDto>(announcementImageModel);
                                if (file != null)
                                    dtoimage.Image = _commonServiceFacade.ConvertImage(announcementImageModel.HttpPostedFileBase);
                                var response1 = _announcementImageServiceFacade.Save(dtoimage);
                            }
                            foreach (var item in announcementModel.PhoneNumbers)
                            {
                                item.AnnouncementId = dtoannounce.Id;
                                var dtophone = Mapper.Map<PhoneNumberDto>(item);
                                var response2 = _phoneNumberServiceFacade.Save(dtophone);

                            }

                            var subject = dtoannounce.Title + " Your listing has been added!";
                            var link = $"{Request.Url.Scheme}://{Request.Url.Authority}/items/{{0}}";
                            _announcementServiceFacade.SendConfirmation(dtoannounce.Email, link, dtoannounce.Title, dtoannounce.Id);
                            responsemain.Success("Your listing has been added!");
                            return Json(responsemain, JsonRequestBehavior.AllowGet);
                        }

                        return Json(response);
                    }
                    responsemain.Failure("At least 4 pictures should be selected");
                    return Json(responsemain, JsonRequestBehavior.AllowGet);
                }
                responsemain.Failure(UI.YouAreLimited);
                return Json(responsemain, JsonRequestBehavior.AllowGet);
            }
            responsemain.Failure(UI.CustomerNotFound);
            return Json(responsemain, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddPhone(int length)
        {

            var response = new SiteResponse();
            if (length < 4)
            {
                var model = new PhoneNumberModel();
                return PartialView("Partials/PhonePartials/_PhoneFormPartial", model);
            }
            return Json(response, length.ToString(), JsonRequestBehavior.AllowGet);
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
                    .Where(x => x.DepartamentId == dpId)
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
            var dto = _announcementImageServiceFacade.GetById(id, Status.Active);
            var model = Mapper.Map<AnnouncementImageModel>(dto);
            var imageStr = model.Image;
            return File(imageStr, "image/gif");
        } 
        #endregion

    }
}