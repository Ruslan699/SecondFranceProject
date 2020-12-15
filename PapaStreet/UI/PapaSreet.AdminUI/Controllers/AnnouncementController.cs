using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly AnnouncementManageServiceFacade _announcementManageServiceFacade;
        private readonly AnnouncementImageServiceFacade _announcementImageServiceFacade;
        private readonly AnnouncementTypeServiceFacade _announcementTypeServiceFacade;
        private readonly DocumentTypeServiceFacade _documentTypeServiceFacade;
        private readonly PropertyTypeServiceFacade _propertyTypeServiceFacade;
        private readonly RepairServiceFacade _repairServiceFacade;
        private readonly PhoneNumberServiceFacade _phoneNumberServiceFacade;
        private readonly CityServiceFacade _cityServiceFacade;
        private readonly CommonServiceFacade _commonServiceFacade;
        private readonly RegionServiceFacade _regionServiceFacade;
        private readonly DepartamentServiceFacade _departamentServiceFacade;
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        private readonly CustomerServiceFacade _customerServiceFacade;
        private readonly FrequencyServiceFacade _frequencyServiceFacade;
        private readonly PricePlanHistoryServiceFacade _pricePlanHistoryServiceFacade;
        private readonly AnnouncementAdditionServiceFacade _announcementAdditionServiceFacade;

        public AnnouncementController(AnnouncementManageServiceFacade announcementManageServiceFacade,
           AnnouncementImageServiceFacade announcementImageServiceFacade,
           AnnouncementTypeServiceFacade announcementTypeServiceFacade,
           DocumentTypeServiceFacade documentTypeServiceFacade,
           PropertyTypeServiceFacade propertyTypeServiceFacade, RepairServiceFacade repairServiceFacade,
           PhoneNumberServiceFacade phoneNumberServiceFacade, CityServiceFacade cityServiceFacade,
           CommonServiceFacade commonServiceFacade, RegionServiceFacade regionServiceFacade, DepartamentServiceFacade departamentServiceFacade,
           PricePlanServiceFacade pricePlanServiceFacade, PricePlanHistoryServiceFacade pricePlanHistoryServiceFacade, 
           CustomerServiceFacade customerServiceFacade, AnnouncementAdditionServiceFacade announcementAdditionServiceFacade,
           FrequencyServiceFacade frequencyServiceFacade)
        {
            _announcementManageServiceFacade = announcementManageServiceFacade;
            _announcementImageServiceFacade = announcementImageServiceFacade;
            _announcementTypeServiceFacade = announcementTypeServiceFacade;
            _documentTypeServiceFacade = documentTypeServiceFacade;
            _propertyTypeServiceFacade = propertyTypeServiceFacade;
            _repairServiceFacade = repairServiceFacade;
            _phoneNumberServiceFacade = phoneNumberServiceFacade;
            _cityServiceFacade = cityServiceFacade;
            _commonServiceFacade = commonServiceFacade;
            _regionServiceFacade = regionServiceFacade;
            _departamentServiceFacade = departamentServiceFacade;
            _pricePlanServiceFacade = pricePlanServiceFacade;
            _pricePlanHistoryServiceFacade = pricePlanHistoryServiceFacade;
            _customerServiceFacade = customerServiceFacade;
            _announcementAdditionServiceFacade = announcementAdditionServiceFacade;
            _frequencyServiceFacade = frequencyServiceFacade;
           
        }

        #region Announcement 

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _announcementManageServiceFacade.GetAll();
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }

        public ActionResult Form(Guid id)
        {
            ViewBag.Departaments = _departamentServiceFacade.GetAll();
            ViewBag.Cities = _cityServiceFacade.GetAll(Status.Active);
            ViewBag.AnnouncementTypes = _announcementTypeServiceFacade.GetAll(Status.Active);
            ViewBag.DocumentTypes = _documentTypeServiceFacade.GetAll(Status.Active);
            ViewBag.PropertyTypes = _propertyTypeServiceFacade.GetAll(Status.Active);
            ViewBag.Repairs = _repairServiceFacade.GetAll(Status.Active);
            ViewBag.Statuses = _announcementManageServiceFacade.GetAll();
            ViewBag.PricePlans = _pricePlanServiceFacade.GetAll();
            ViewBag.AnnouncementAdditionals = _announcementAdditionServiceFacade.GetAll();
            var dto = _announcementManageServiceFacade.GetById(id);
            var viewModel = Mapper.Map<AnnouncementViewModel>(dto);
            if (viewModel.AnnouncementAddition != null)
            {
                List<string> AnnouncementAdditionalNames = new List<string>();
                viewModel.AnnouncementAdditionals = viewModel.AnnouncementAddition.Split(',');
                foreach (var item in viewModel.AnnouncementAdditionals)
                {
                    var model = _announcementAdditionServiceFacade.GetById((Guid.Parse(item))).Name;
                    AnnouncementAdditionalNames.Add(model);
                }

                viewModel.AnnouncementAdditionalNames = AnnouncementAdditionalNames;
            }
            

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            ViewBag.PricePlans = _pricePlanServiceFacade.GetById(id);          
            var dto = _announcementManageServiceFacade.GetById(id);
            var viewModel = Mapper.Map<AnnouncementViewModel>(dto);
            if (viewModel.AnnouncementAddition == null)
            {
                ViewBag.AnnouncementAdditionals = _announcementAdditionServiceFacade.GetAll();
            }
            else
            {
                viewModel.AnnouncementAdditionals = viewModel.AnnouncementAddition.Split(',');
                List<string> AnnouncementAdditionalNames = new List<string>();
                foreach (var item in viewModel.AnnouncementAdditionals)
                {
                    var model = _announcementAdditionServiceFacade.GetById((Guid.Parse(item))).Name;
                    AnnouncementAdditionalNames.Add(model);
                }

                viewModel.AnnouncementAdditionalNames = AnnouncementAdditionalNames;
            }

            return PartialView("Details", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AnnouncementViewModel announcementViewModel, IEnumerable<HttpPostedFileBase> files)
        {
            var responsemain = new SiteResponse();
            //convert announcement from view model to dto model           
            var customer = _customerServiceFacade.GetAll(Status.Active).FirstOrDefault(c => c.Email == announcementViewModel.Email);
            if (customer != null)
            {
                var priceplanhistory = _pricePlanHistoryServiceFacade.GetAll(Status.Active).FirstOrDefault(p => p.CustomerId == customer.Id);
                if (priceplanhistory.UsedAnnouncementCount > 0)
                {
                    if (announcementViewModel.AnnouncementAdditionals != null || announcementViewModel.AnnouncementAddition !=null)
                        announcementViewModel.AnnouncementAddition = String.Join(",", announcementViewModel.AnnouncementAdditionals);

                    var dtoannounce = Mapper.Map<AnnouncementDto>(announcementViewModel);
                    var expirtationDate = _pricePlanServiceFacade.GetById(customer.PricePlanId);
                    //add publish and expiration dates
                    dtoannounce.PublishedDate = DateTime.Now;
                    #region Check this! Status may not be changed in Expiration Date

                    if (dtoannounce.ExpirationDate == DateTime.UtcNow.AddHours(4).AddDays(expirtationDate.Frequency.DaysCount))
                    {
                        dtoannounce.Status = Status.Deactive;
                    }
                    #endregion

                    //save announcement 
                    var response = _announcementManageServiceFacade.Save(dtoannounce);
                    //if announcement save successfuly 
                    if (response.IsSucceed)
                    {
                        _pricePlanHistoryServiceFacade.DecUsedAnnouncementCount(customer.Id);
                        if (files != null && files.Count() > 2)
                        {
                            foreach (var file in files)
                            {
                                AnnouncementImageViewModel announcementImageModel = new AnnouncementImageViewModel();
                                announcementImageModel.AnnouncementId = dtoannounce.Id;
                                announcementImageModel.HttpPostedFileBase = file;
                                var dtoimage = Mapper.Map<AnnouncementImageDto>(announcementImageModel);
                                if (file != null)
                                    dtoimage.Image = _commonServiceFacade.ConvertImage(announcementImageModel.HttpPostedFileBase);
                                var response1 = _announcementImageServiceFacade.Save(dtoimage);
                                if (!response1.IsSucceed)
                                    return Json(response1);
                            }
                        }

                        foreach (var item in announcementViewModel.PhoneNumbers)
                        {
                            item.AnnouncementId = dtoannounce.Id;
                            var dtophone = Mapper.Map<PhoneNumberDto>(item);
                            var response2 = _phoneNumberServiceFacade.Save(dtophone);
                            if (!response2.IsSucceed)
                                return Json(response2);
                        }
                        return Json(response);
                    }
                    return Json(response);

                }
                responsemain.Failure("You are in limit");
                return Json(responsemain, JsonRequestBehavior.AllowGet);
            }
            responsemain.Failure(UI.CustomerNotFound);
            return Json(responsemain, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _announcementManageServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(Guid id, string message)
        {
            var response = new SiteResponse();
            var dto = _announcementManageServiceFacade.GetById(id);
            if (dto.Id == default(Guid))
            {
                response.Failure("Announcement Not Found");
                return Json(response);
            }
            dto.Status = Status.Active;
            dto.PublishedDate = DateTime.Now;
            dto.ExpirationDate = DateTime.Today.AddDays(+30);
            var updatedData = _announcementManageServiceFacade.Save(dto);
            if (updatedData.IsSucceed)
            {
                if (message == null)
                    message = "Your Announcement confirmed!";
                MailHelper.SendEmail(dto.Email, dto.Title, message);
            }
            return Json(updatedData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(Guid id, string message)
        {
            var response = new SiteResponse();
            var dto = _announcementManageServiceFacade.GetById(id);
            if (dto.Id == default(Guid))
            {
                response.Failure("Announcement Not Found");
                return Json(response);
            }
            dto.Status = Status.Rejected;
            var updatedData = _announcementManageServiceFacade.Save(dto);
            if (updatedData.IsSucceed)
            {
                if (message == null)
                    message = "Your Announcement rejected!";
                MailHelper.SendEmail(dto.Email, dto.Title, message);
            }
            return Json(updatedData);
        }

        #endregion

        #region AnnouncementImage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAnnouncementImage(SaveAnnouncementImageViewModel saveAnnouncementImageViewModel)
        {
            var response = new SiteResponse();

            foreach (var image in saveAnnouncementImageViewModel.Images)
            {
                var imageDto = new AnnouncementImageDto()
                {
                    AnnouncementId = saveAnnouncementImageViewModel.AnnouncementId,
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                };

                imageDto.Image = ConvertHelper.ToBinary(image);
                response = _announcementImageServiceFacade.Save(imageDto);
                if (!response.IsSucceed)
                    return Json(response);
            }
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePicture(Guid id)
        {
            var response = _announcementImageServiceFacade.Remove(id);
            return Json(response);
        }

        #endregion

        #region AnnouncementPhone

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPhone(int length)
        {
            var response = new SiteResponse();
            if (length < 4)
            {
                var model = new PhoneNumberViewModel();
                return PartialView("Partials/_PhoneFormPartial", model);
            }
            return Json(response, length.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveAnnouncementPhone(Guid id)
        {
            var response = new SiteResponse();
            if (id != null)
                response = _phoneNumberServiceFacade.Remove(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}