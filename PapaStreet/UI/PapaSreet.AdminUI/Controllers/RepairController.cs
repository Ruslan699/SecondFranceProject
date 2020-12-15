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
    public class RepairController : BaseController
    {
        private readonly RepairServiceFacade _repairServiceFacade;

        public RepairController(RepairServiceFacade repairServiceFacade)
        {
            _repairServiceFacade = repairServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _repairServiceFacade.GetById(id);
            var viewModel = Mapper.Map<RepairViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _repairServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RepairViewModel repairType)
        {
            var dto = Mapper.Map<RepairDto>(repairType);
            var response = _repairServiceFacade.Save(dto);
            return Json(response);
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _repairServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}