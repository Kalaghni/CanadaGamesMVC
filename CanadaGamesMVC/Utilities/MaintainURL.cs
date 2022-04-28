using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanadaGamesMVC.Utilities
{
    public static class MaintainURL
    {
        /// <summary>
        /// Maintain the URL for and Index View including filter, sort and page informaiton.
        /// Warning: Works with our default route by setting the href to /Controller
        /// so you may need to make adjustments for a custom route.
        /// </summary>
        /// <param name="httpContext">the HttpContext from the Controller</param>
        /// <param name="ControllerName">The Name of the Controller</param>
        /// <returns>The Index URL with paramerters if required</returns>
        public static string ReturnURL(HttpContext httpContext, string ControllerName)
        {
            string cookieName = ControllerName + "URL";
            string SearchText = "/" + ControllerName + "?";
            string returnURL = httpContext.Request.Headers["Referer"].ToString();
            if (returnURL.Contains(SearchText))
            {
                returnURL = returnURL[returnURL.LastIndexOf(SearchText)..];
                CookieHelper.CookieSet(httpContext, cookieName, returnURL, 30);
                return returnURL;
            }
            else
            {
                returnURL = httpContext.Request.Cookies[cookieName];
                return returnURL ?? "/" + ControllerName;
            }
        }
    }
}
