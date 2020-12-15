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
    public class RegionController : BaseController
    {
        private readonly RegionServiceFacade _regionServiceFacade;

        public RegionController(RegionServiceFacade regionServiceFacade)
        {
            _regionServiceFacade = regionServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _regionServiceFacade.GetById(id);
            var viewModel = Mapper.Map<RegionViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _regionServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RegionViewModel region)
        {
            var dto = Mapper.Map<RegionDto>(region);
            var response = _regionServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _regionServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}