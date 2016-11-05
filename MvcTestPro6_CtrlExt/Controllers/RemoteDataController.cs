using System.Threading.Tasks;
using System.Web.Mvc;
using MvcTestPro6_CtrlExt.Infrastructure;

namespace MvcTestPro6_CtrlExt.Controllers
{
    public class RemoteDataController : Controller
    {        
        //public ActionResult Data()
        //{
        //    return View((object)new RemoteService().GetRemoteData());
        //}

        public async Task<ActionResult> Data()
        {
            var data = await Task.Run(() => new RemoteService().GetRemoteData());
            return View((object) data);
        }

        [ActionName("DataAsync")]
        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            var data = await new RemoteService().GetRemoteDataAsync();
            return View("Data", (object) data);
        }
    }
}