using AutoMapper;
using PapaSreet.AdminUI.Models;
using PapaSreet.AdminUI.Security;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.DTOs;
using System.Web.Mvc;

namespace PapaSreet.AdminUI.Controllers
{
    public class AdminController : BaseController
    {
        private readonly UserServiceFacade _userServiceFacade;

        public AdminController(UserServiceFacade userServiceFacade)
        {
            _userServiceFacade = userServiceFacade;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel user)
        {
            var dto = Mapper.Map<UserDto>(user);
            var response = _userServiceFacade.Login(dto);
            return Json(response);
        } 

        [HttpGet]
        public ActionResult Logout()
        {
            CustomIdentity.Logout();
            return RedirectToAction(nameof(Login));
        }

        #region ManageUsersByAdmin
        //public ActionResult Form(Guid id)
        //{
        //    var dto = _userServiceFacade.GetById(id);
        //    var viewModel = Mapper.Map<UserViewModel>(dto);
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Remove(Guid id)
        //{
        //    var response = _userServiceFacade.Remove(id);
        //    return Json(response);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(UserViewModel userViewModel)
        //{
        //    var dto = Mapper.Map<UserDto>(userViewModel);
        //    var response = _userServiceFacade.Save(dto);
        //    return Json(response);
        //}


        //public ActionResult Data(DataSourceLoadOptions loadOptions)
        //{
        //    var data = _userServiceFacade.GetAll(Status.Active);
        //    var loadResult = DataSourceLoader.Load(data, loadOptions);
        //    return Content(GetSerializeObject(loadResult), "application/json");
        //}
        #endregion
    }
}