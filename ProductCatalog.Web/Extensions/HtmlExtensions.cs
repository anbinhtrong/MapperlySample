using System;
using System.Web.Mvc;

namespace ProductCatalog.Web.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Truncate text to a specified length and add ellipsis
        /// </summary>
        public static MvcHtmlString Truncate(this HtmlHelper html, string text, int length)
        {
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Empty;

            if (text.Length <= length)
                return MvcHtmlString.Create(text);

            return MvcHtmlString.Create(text.Substring(0, length) + "...");
        }
    }
}
