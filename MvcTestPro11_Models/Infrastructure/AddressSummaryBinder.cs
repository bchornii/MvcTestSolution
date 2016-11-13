using System.Web.Mvc;
using MvcTestPro11_Models.Models;

namespace MvcTestPro11_Models.Infrastructure
{
    public class AddressSummaryBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (AdressSummary) bindingContext.Model ?? new AdressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            return model;
        }

        private static string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? "" : context.ModelName + ".") + name;
            ValueProviderResult res = context.ValueProvider.GetValue(name);
            if (res == null || res.AttemptedValue == "")
            {
                return "<Not selected>";
            }
            return res.AttemptedValue;
        }
    }
}