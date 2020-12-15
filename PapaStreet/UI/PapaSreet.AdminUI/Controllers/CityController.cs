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
    public class CityController : BaseController
    {
        private readonly CityServiceFacade _cityServiceFacade;

        public CityController(CityServiceFacade cityServiceFacade)
        {
            _cityServiceFacade = cityServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _cityServiceFacade.GetById(id);
            var viewModel = Mapper.Map<CityViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _cityServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CityViewModel city)
        {
            var dto = Mapper.Map<CityDto>(city);
            var response = _cityServiceFacade.Save(dto);
            return Json(response);
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _cityServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}