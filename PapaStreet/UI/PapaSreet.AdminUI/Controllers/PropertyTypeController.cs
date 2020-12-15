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
    public class PropertyTypeController : BaseController
    {
        private readonly PropertyTypeServiceFacade _propertyTypeServiceFacade;
        public PropertyTypeController(PropertyTypeServiceFacade propertyTypeServiceFacade)
        {
            _propertyTypeServiceFacade = propertyTypeServiceFacade;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form(Guid id)
        {
            var dto = _propertyTypeServiceFacade.GetById(id);
            var viewModel = Mapper.Map<PropertyTypeViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _propertyTypeServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PropertyTypeViewModel propertyType)
        {
            var dto = Mapper.Map<PropertyTypeDto>(propertyType);
            var response = _propertyTypeServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _propertyTypeServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}