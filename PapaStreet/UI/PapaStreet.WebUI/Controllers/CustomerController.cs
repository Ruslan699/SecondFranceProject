using AutoMapper;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Helpers;
using PapaStreet.Common.Resources;
using PapaStreet.Common.Responses;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.Security;
using PapaStreet.WebUI.ServiceFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Controllers
{
    [AuthFilter]
    public class CustomerController : BaseController
    {
        private readonly CustomerServiceFacade _customerServiceFacade;
        private readonly CustomerPhoneNumberServiceFacade _customerPhoneNumberServiceFacade;
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        private readonly PricePlanHistoryServiceFacade _pricePlanHistoryServiceFacade;
        public CustomerController(CustomerServiceFacade customerServiceFacade,
            CustomerPhoneNumberServiceFacade customerPhoneNumberServiceFacade,
            PricePlanServiceFacade pricePlanServiceFacade,
            PricePlanHistoryServiceFacade pricePlanHistoryServiceFacade
            )
        {
            _customerServiceFacade = customerServiceFacade;
            _customerPhoneNumberServiceFacade = customerPhoneNumberServiceFacade;
            _pricePlanServiceFacade = pricePlanServiceFacade;
            _pricePlanHistoryServiceFacade = pricePlanHistoryServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }


        [Route("profil/{id}")]
        public ActionResult Profil(Guid id)
        {
            var dto = _customerServiceFacade.GetById(id);
            var model = Mapper.Map<CustomerModel>(dto);
            model.PricePlanStatus = false;
            var customerpriceplan = _pricePlanHistoryServiceFacade.GetAll(Status.Active).FirstOrDefault(x => x.CustomerId == id);
            if (customerpriceplan.UsedAnnouncementCount <= 0 || customerpriceplan.EndDate < DateTime.UtcNow.AddHours(4))
            {
                ViewBag.PricePlans = _pricePlanServiceFacade.GetAll(Status.Active);
                model.PricePlanStatus = true;
            }
            return View(model);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult PricePlan(Guid id)
        //{
        //    var priceplan = _pricePlanServiceFacade.GetById(id, Status.Active);
        //    var response = new SiteResponse();
        //    if (priceplan !=null)
        //    {
        //        response.IsSucceed = true;
        //        Session["permission"] = id;
        //        var link = $"{Request.Url.Scheme}://{Request.Url.Authority}/register";
        //        response.Success(link);
        //        return Json(response, JsonRequestBehavior.AllowGet);
        //    }
        //    response.IsSucceed = false;
        //    response.Failure("Duzgun Secim edin");
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult UpdatePricePlan(Guid id, Guid customerId)
        {
            var priceplan = _pricePlanServiceFacade.GetById(id, Status.Active);
           
            var response = new SiteResponse();
            if (priceplan != null)
            {
                var customer = _customerServiceFacade.GetById(customerId, Status.Active);
                if (customer != null)
                {
                    var priceplanhistory = _pricePlanHistoryServiceFacade.GetAll(Status.Active).FirstOrDefault(x => x.CustomerId == customer.Id);
                    var FrompriceplanId = priceplanhistory.ToPricePlanId;
                    priceplanhistory.FromPricePlanId = FrompriceplanId;
                    priceplanhistory.ToPricePlanId = priceplan.Id;
                    priceplanhistory.StartDate = DateTime.UtcNow.AddHours(4);
                    priceplanhistory.EndDate = DateTime.UtcNow.AddHours(4).AddDays(priceplan.Duration.DaysCount);
                    priceplanhistory.UsedAnnouncementCount = priceplan.AnnouncementCount;
                    var response1 =  _pricePlanHistoryServiceFacade.Save(priceplanhistory);
                    if (response1.IsSucceed)
                    {
                        var link = $"{Request.Url.Scheme}://{Request.Url.Authority}/PapaStreet/profil/{{0}}";
                        response.Success(string.Format(link, customer.Id));
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                    response.Success("");
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                response.IsSucceed = false;
                response.Success(UI.CustomerNotFound);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            response.IsSucceed = false;
            response.Failure(UI.MakeTheRightChoice);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult Register(CustomerModel customerModel)
        {
            var response = new SiteResponse();
            Identity.RegisterCustomer = Mapper.Map<CustomerDto>(customerModel);
            if (Identity.RegisterCustomer == null)
                response.IsSucceed = false;
            return Json(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterContinue(Guid PricePlanId)
        {
            if (Identity.RegisterCustomer != null || PricePlanId!=null)
            {
                var mainresponse = new SiteResponse();
                var priceplan = _pricePlanServiceFacade.GetById(PricePlanId, Status.Active);
                if (priceplan != null)
                {
                    Identity.RegisterCustomer.PricePlanId = PricePlanId;
                    var dto = Identity.RegisterCustomer;
                    var response = _customerServiceFacade.Register(dto);
                    if (response.IsSucceed)
                    {
                        var priceplanhistory = new PricePlanHistoryDto();
                        priceplanhistory.CustomerId = dto.Id;
                        priceplanhistory.FromPricePlanId = dto.PricePlanId;
                        priceplanhistory.ToPricePlanId = dto.PricePlanId;
                        priceplanhistory.StartDate = DateTime.UtcNow.AddHours(4);
                        priceplanhistory.EndDate = DateTime.UtcNow.AddHours(4).AddDays(priceplan.Duration.DaysCount);
                        priceplanhistory.UsedAnnouncementCount = priceplan.AnnouncementCount;
                        _pricePlanHistoryServiceFacade.Save(priceplanhistory);
                        var link = $"{Request.Url.Scheme}://{Request.Url.Authority}/PapaStreet/profil/{{0}}";
                        response.Description = string.Format(link, dto.Id);
                    }
                    return Json(response);
                }
                mainresponse.IsSucceed = false;
                mainresponse.Failure(UI.MakeTheRightChoice);
                return Json(mainresponse, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update(CustomerModel customerModel)
        {
            foreach (var item in customerModel.CustomerNumbers)
            {
                item.CustomerId = customerModel.Id;
                var dtophone = Mapper.Map<CustomerPhoneNumberDto>(item);
                var response2 = _customerPhoneNumberServiceFacade.Save(dtophone);
            }

            var dto = Mapper.Map<CustomerDto>(customerModel);
            var response = _customerServiceFacade.Save(dto);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(CustomerModel model)
        {
            Thread.Sleep(1000);
            var response = new SiteResponse();
            var dto = _customerServiceFacade.GetById(model.Id, Status.Active);
            if (dto == null)
            {
                response.Failure(UI.CustomerNotFound);
                return Json(response);
            }
            if (HashHelper.Verify(dto.Password, model.Password))
                response = _customerServiceFacade.ResetPassword(dto.Email, model.NewPassword, Status.Active);
            else response.Failure(UI.PasswordNotCorrect);

            return Json(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login()
        {
            Identity.Logout();
            return View("LoginAndRegister");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login(CustomerModel customerModel)
        {
            Thread.Sleep(1000);
            var dto = Mapper.Map<CustomerDto>(customerModel);
            var response = _customerServiceFacade.Login(dto);
            return Json(response);
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            Identity.Logout();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public ActionResult AddCustomerPhone(int length)
        {
            var response = new SiteResponse();
            if (length < 5)
            {
                var model = new CustomerPhoneNumberModel();
                return PartialView("Partials/CustomerPhonePartials/_CustomerPhoneFormPartial", model);
            }
            return Json(response, length.ToString(), JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult RemoveCustomerPhone(Guid id)
        {
            var response = new SiteResponse();
            if (id != null)
                response = _customerPhoneNumberServiceFacade.Remove(id);
            return Json(response,JsonRequestBehavior.AllowGet);
        }
    }
}