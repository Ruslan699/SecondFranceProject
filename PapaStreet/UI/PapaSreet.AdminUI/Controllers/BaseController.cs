using DevExtreme.AspNet.Data.ResponseModel;
using Newtonsoft.Json;
using PapaSreet.AdminUI.Security;
using System.Web.Mvc;

namespace PapaSreet.AdminUI.Controllers
{
    [AuthFilter]
    public abstract class BaseController : Controller
    {
        public string GetSerializeObject(LoadResult loadResult)
        {
            return JsonConvert.SerializeObject(loadResult, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
        }
    }
}