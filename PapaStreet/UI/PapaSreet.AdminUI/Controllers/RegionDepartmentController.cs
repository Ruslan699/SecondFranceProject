using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class RegionDepartmentController : BaseController
    {
        private readonly RegionDepartamentServiceFacade _regionDepartamentServiceFacade;
        private readonly RegionServiceFacade _regionServiceFacade;
        private readonly DepartamentServiceFacade _departamentServiceFacade;

        public RegionDepartmentController(RegionDepartamentServiceFacade regionDepartamentServiceFacade, RegionServiceFacade regionServiceFacade, 
                                          DepartamentServiceFacade departamentServiceFacade)
        {
            _regionDepartamentServiceFacade = regionDepartamentServiceFacade;
            _regionServiceFacade = regionServiceFacade;
            _departamentServiceFacade = departamentServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _regionDepartamentServiceFacade.GetAll();
            var t = data.Take(10).ToList();
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }

        public ActionResult Form(Guid id)
        {
            ViewBag.Regions = _regionServiceFacade.GetAll(Status.Active);
            ViewBag.Departments = _departamentServiceFacade.GetAll(Status.Active);
            var dto = _regionDepartamentServiceFacade.GetById(id);
            var viewModel = Mapper.Map<RegionDepartamentViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _regionDepartamentServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RegionDepartamentViewModel regionDepartament)
        {
            var dto = Mapper.Map<RegionDepartamentDto>(regionDepartament);
            var response = _regionDepartamentServiceFacade.Save(dto);
            return Json(response);
        }

    }
}