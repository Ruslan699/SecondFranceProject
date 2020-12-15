using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Responses;
using System;
using System.Linq;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerServiceFacade _customerServiceFacade;
        private readonly CustomerPhoneServiceFacade _phoneNumberServiceFacade;
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        private readonly PricePlanHistoryServiceFacade _pricePlanHistoryServiceFacade;

        public CustomerController(CustomerServiceFacade customerServiceFacade, CustomerPhoneServiceFacade phoneNumberServiceFacade,
                                  PricePlanServiceFacade pricePlanServiceFacade, PricePlanHistoryServiceFacade pricePlanHistoryServiceFacade)
        {
            _customerServiceFacade = customerServiceFacade;
            _phoneNumberServiceFacade = phoneNumberServiceFacade;
            _pricePlanServiceFacade = pricePlanServiceFacade;
            _pricePlanHistoryServiceFacade = pricePlanHistoryServiceFacade;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _customerServiceFacade.GetAll();
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }

        public ActionResult Form(Guid id)
        {
            var dto = _customerServiceFacade.GetById(id);
            var viewModel = Mapper.Map<CustomerViewModel>(dto);
            var CustomerPricePlan = _pricePlanHistoryServiceFacade.GetAll(Status.Active).FirstOrDefault(x => x.CustomerId == id);
            if (CustomerPricePlan.UsedAnnouncementCount < 0 || CustomerPricePlan.EndDate < DateTime.UtcNow.AddHours(4))
                ViewBag.PricePlans = _pricePlanServiceFacade.GetAll(Status.Active);
                return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var dto = _customerServiceFacade.GetById(id);
            return PartialView("Details", dto);
        }

        #region Customer Remove and Block
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _customerServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel customer)
        {
            foreach (var item in customer.CustomerNumbers)
            {
                item.CustomerId = customer.Id;
                var dtophone = Mapper.Map<CustomerPhoneNumberDto>(item);
                var response2 = _phoneNumberServiceFacade.Save(dtophone);
            }
            var dto = Mapper.Map<CustomerDto>(customer);
            var response = _customerServiceFacade.Save(dto);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Block(Guid id)
        {
            var response = new SiteResponse();
            var dto = _customerServiceFacade.GetById(id);
            if (dto.Id == default(Guid))
            {
                response.Failure("Customer not blocked");
                return Json(response);
            }
            dto.Status = Status.Blocked;
            var updatedData = _customerServiceFacade.Save(dto);
            return Json(updatedData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unblock(Guid id)
        {
            var response = new SiteResponse();
            var dto = _customerServiceFacade.GetById(id);
            if (dto.Id == default(Guid))
            {
                response.Failure("Customer blocked");
                return Json(response);
            }
            dto.Status = Status.Active;
            var updatedData = _customerServiceFacade.Save(dto);
            return Json(updatedData);
        }
        #endregion

        #region Customer Phone Add and Remove
        [HttpGet]
        public ActionResult AddCustomerPhone(int length)
        {
            var response = new SiteResponse();
            if (length < 5)
            {
                var model = new CustomerPhoneViewModel();
                return PartialView("Partials/CustomerPhonePartials/_CustomerPhoneFormPartial", model);
            }
            return Json(response, length.ToString(), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult RemoveCustomerPhone(Guid id)
        {
            var response = new SiteResponse();
            if (id != null)
                response = _phoneNumberServiceFacade.Remove(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}