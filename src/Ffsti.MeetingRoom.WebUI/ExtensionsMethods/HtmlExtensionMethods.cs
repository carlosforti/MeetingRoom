using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc.Html;

namespace System.Web.Mvc.Html
{
    public static class HtmlExtensionMethods
    {   
        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string sortOrder, string currentFilter)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { sortOrder = sortOrder, currentFilter = currentFilter });
        }

        public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, int page, string sortOrder, string currentFilter)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { page = page, sortOrder = sortOrder, currentFilter = currentFilter });
        }
    }
}