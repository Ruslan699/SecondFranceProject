using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.Security;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using PapaStreet.Common.Resources;
using System;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaSreet.AdminUI.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserServiceFacade _userServiceFacade;

        public UserController(UserServiceFacade userServiceFacade)
        {
            _userServiceFacade = userServiceFacade;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _userServiceFacade.GetById(id);
            var viewModel = Mapper.Map<UserViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _userServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserViewModel user)
        {
            var dto = Mapper.Map<UserDto>(user);
            var response = _userServiceFacade.Save(dto);
            return Json(response);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            ViewBag.Menu = UI.ChangePassword;
            var model = new ChangePasswordViewModell() { Id = CustomIdentity.User.Id };
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModell model)
        {
            var response = _userServiceFacade.ChangePassword(model);
            return Json(response);
        }

        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _userServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}