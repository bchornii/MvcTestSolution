using System.IO;
using System.Web.Mvc;

namespace MvcTestPro7_Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            Write(writer, "--- Route data ---");
            foreach (var key in viewContext.RouteData.Values.Keys)
            {
                Write(writer, $"Key:{key}, Value:{viewContext.RouteData.Values[key]}");
            }

            Write(writer, "--- View data ---");
            foreach (var key in viewContext.ViewData.Keys)
            {
                Write(writer, $"Key: {key}, Value:{viewContext.ViewData[key]}");
            }
        }

        private void Write(TextWriter writer, string template, params object[] values)
        {
            writer.Write($"{template}{values} <p/>");
        }
    }
}