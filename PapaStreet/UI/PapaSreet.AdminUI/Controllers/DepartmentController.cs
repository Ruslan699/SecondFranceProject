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
    public class DepartmentController : BaseController
    {
        private readonly DepartamentServiceFacade _departamentServiceFacade;

        public DepartmentController(DepartamentServiceFacade departamentServiceFacade)
        {
            _departamentServiceFacade = departamentServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _departamentServiceFacade.GetById(id);
            var viewModel = Mapper.Map<DepartmentViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _departamentServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DepartmentViewModel department)
        {
            var dto = Mapper.Map<DepartamentDto>(department);
            var response = _departamentServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _departamentServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}