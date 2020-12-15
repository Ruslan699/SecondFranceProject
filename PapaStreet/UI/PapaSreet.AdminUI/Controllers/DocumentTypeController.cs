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
    public class DocumentTypeController : BaseController
    {
        private readonly DocumentTypeServiceFacade _documentTypeServiceFacade;
        public DocumentTypeController(DocumentTypeServiceFacade documentTypeServiceFacade)
        {
            _documentTypeServiceFacade = documentTypeServiceFacade;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(Guid id)
        {
            var dto = _documentTypeServiceFacade.GetById(id);
            var viewModel = Mapper.Map<DocumentTypeViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Guid id)
        {
            var response = _documentTypeServiceFacade.Remove(id);
            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DocumentTypeViewModel documentType)
        {
            var dto = Mapper.Map<DocumentTypeDto>(documentType);
            var response = _documentTypeServiceFacade.Save(dto);
            return Json(response);
        }


        public ActionResult Data(DataSourceLoadOptions loadOptions)
        {
            var data = _documentTypeServiceFacade.GetAll(Status.Active);
            var loadResult = DataSourceLoader.Load(data, loadOptions);
            return Content(GetSerializeObject(loadResult), "application/json");
        }
    }
}