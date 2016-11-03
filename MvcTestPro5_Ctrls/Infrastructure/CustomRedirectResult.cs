using System.Web.Mvc;

namespace MvcTestPro5_Ctrls.Infrastructure
{
    public class CustomRedirectResult : ActionResult
    {
        public string Url { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            var fullUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
            context.HttpContext.Response.Redirect(fullUrl);
        }
    }
}