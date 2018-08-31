using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaRadarAdData.Helpers
{
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Sets the active class for the selected navigation item
        /// </summary>
        /// <param name="html"></param>
        /// <param name="control"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IsActive(this HtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];
            
            var returnActive = control == routeControl && action == routeAction;

            return returnActive ? "active" : "";
        }
    }
}