using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using System;
using System.Web.Mvc;

namespace PapaSreet.AdminUI.Controllers
{
    public class GenericAnnouncementController : BaseController
    {
        private readonly GenericAnnouncementServiceFacade _genericAnnouncementServiceFacade;

        public GenericAnnouncementController(GenericAnnouncementServiceFacade genericAnnouncementServiceFacade)
        {
            _genericAnnouncementServiceFacade = genericAnnouncementServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _genericAnnouncementServiceFacade.GetById(id);
            var viewModel = Mapper.Map<GenericAnnouncementViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _genericAnnouncementServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GenericAnnouncementViewModel genericAnnouncement)
        {
            var dto = Mapper.Map<GenericAnnouncementDto>(genericAnnouncement);
            var response = _genericAnnouncementServiceFacade.Save(dto);
            return Json(response);
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _genericAnnouncementServiceFacade.GetAll();
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}