using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using System;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class PricePlanHistoryController : BaseController
    {
        private readonly PricePlanHistoryServiceFacade _pricePlanHistoryServiceFacade;
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        private readonly CustomerServiceFacade _customerServiceFacade;

        public PricePlanHistoryController(PricePlanHistoryServiceFacade pricePlanHistoryServiceFacade, PricePlanServiceFacade pricePlanServiceFacade,
                                          CustomerServiceFacade customerServiceFacade)
        {
            _pricePlanHistoryServiceFacade = pricePlanHistoryServiceFacade;
            _pricePlanServiceFacade = pricePlanServiceFacade;
            _customerServiceFacade = customerServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _pricePlanHistoryServiceFacade.GetById(id);
            var pricePlans = _pricePlanServiceFacade.GetAll(Status.Active);
            var customers = _customerServiceFacade.GetAll();
            return View(dto);
            #region With ViewModel
            //var viewModel = Mapper.Map<PricePlanHistoryViewModel>(dto);
            //dto.FromPricePlan = pricePlans;
            //dto.ToPricePlan = pricePlans;
            //dto.Customer = customers;
            #endregion
        }


        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var dto = _pricePlanHistoryServiceFacade.GetById(id);
            return PartialView("Details", dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _pricePlanServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PricePlanHistoryViewModel pricePlanHistory)
        {
            var dto = Mapper.Map<PricePlanHistoryDto>(pricePlanHistory);
            var response = _pricePlanHistoryServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _pricePlanHistoryServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}