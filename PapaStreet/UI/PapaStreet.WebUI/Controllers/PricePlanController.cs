using PapaStreet.WebUI.ServiceFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.WebUI.Controllers
{
    public class PricePlanController : BaseController
    {
        private readonly PricePlanServiceFacade _pricePlanServiceFacade;
        public PricePlanController(PricePlanServiceFacade pricePlanServiceFacade)
        {
            _pricePlanServiceFacade = pricePlanServiceFacade;
        }
        public ActionResult Index()
        {
            var model = _pricePlanServiceFacade.GetAll(Status.Active);
            return PartialView("Partials/PricePlanModalPartials/_ModalPartial", model);
        }
    }
}