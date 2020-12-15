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
    public class AnnouncementTypeController : BaseController
    {
        private readonly AnnouncementTypeServiceFacade _announcementTypeServiceFacade;

        public AnnouncementTypeController(AnnouncementTypeServiceFacade announcementTypeServiceFacade)
        {
            _announcementTypeServiceFacade = announcementTypeServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _announcementTypeServiceFacade.GetById(id);
            var viewModel = Mapper.Map<AnnouncementTypeViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _announcementTypeServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AnnouncementTypeViewModel announcement)
        {
            var dto = Mapper.Map<AnnouncementTypeDto>(announcement);
            var response = _announcementTypeServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _announcementTypeServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data,loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}