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
    public class AnnouncementAdditionController : BaseController
    {
        private readonly AnnouncementAdditionServiceFacade _announcementAdditionServiceFacade;

        public AnnouncementAdditionController(AnnouncementAdditionServiceFacade announcementAdditionServiceFacade)
        {
            _announcementAdditionServiceFacade = announcementAdditionServiceFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _announcementAdditionServiceFacade.GetById(id);
            var viewModel = Mapper.Map<AnnouncementAdditionViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _announcementAdditionServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AnnouncementAdditionViewModel announcementAddition)
        {
            var dto = Mapper.Map<AnnouncementAdditionDto>(announcementAddition);
            var response = _announcementAdditionServiceFacade.Save(dto);
            return Json(response);
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _announcementAdditionServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}