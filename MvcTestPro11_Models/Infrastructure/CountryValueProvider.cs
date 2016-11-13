using System;
using System.Globalization;
using System.Web.Mvc;

namespace MvcTestPro11_Models.Infrastructure
{
    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country") > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            return ContainsPrefix(key) ? new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture) : null;
        }
    }
}