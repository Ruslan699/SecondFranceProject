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
    public class PricePlanController : BaseController
    {
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        private readonly FrequencyServiceFacade _frequencyServiceFacade;

        public PricePlanController(PricePlanServiceFacade pricePlanServiceFacade,
            FrequencyServiceFacade frequencyServiceFacade)
        {
            _pricePlanServiceFacade = pricePlanServiceFacade;
            _frequencyServiceFacade = frequencyServiceFacade;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _pricePlanServiceFacade.GetById(id);
            var viewModel = Mapper.Map<PricePlanViewModel>(dto);
            var frequencies = _frequencyServiceFacade.GetAll(Status.Active);
            viewModel.Frequencies = frequencies;
            viewModel.Durations = frequencies;
            return View(viewModel);
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
        public ActionResult Save(PricePlanViewModel pricePlan)
        {
            var dto = Mapper.Map<PricePlanDto>(pricePlan);
            var response = _pricePlanServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _pricePlanServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}