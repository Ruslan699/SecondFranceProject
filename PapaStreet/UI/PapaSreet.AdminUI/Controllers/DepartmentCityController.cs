using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using System;
using System.Linq;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class DepartmentCityController : BaseController
    {
        private readonly DepartamentCityServiceFacade _departamentCityServiceFacade;
        private readonly DepartamentServiceFacade _departamentServiceFacade;
        private readonly CityServiceFacade _cityServiceFacade;

        public DepartmentCityController(DepartamentCityServiceFacade departamentCityServiceFacade, DepartamentServiceFacade departamentServiceFacade,
                                        CityServiceFacade cityServiceFacade)
        {
            _departamentCityServiceFacade = departamentCityServiceFacade;
            _departamentServiceFacade = departamentServiceFacade;
            _cityServiceFacade = cityServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _departamentCityServiceFacade.GetAll();
            var t = data.Take(10).ToList();
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }

        public ActionResult Form(Guid id)
        {
            ViewBag.Cities = _cityServiceFacade.GetAll(Status.Active);
            ViewBag.Departments = _departamentServiceFacade.GetAll(Status.Active);
            var dto = _departamentCityServiceFacade.GetById(id);
            var viewModel = Mapper.Map<DepartmentCityViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _departamentCityServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DepartmentCityViewModel departmentCity)
        {
            var dto = Mapper.Map<DepartamentCityDto>(departmentCity);
            var response = _departamentCityServiceFacade.Save(dto);
            return Json(response);
        }

    }
}