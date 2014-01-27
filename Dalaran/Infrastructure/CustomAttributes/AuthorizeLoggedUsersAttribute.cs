using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dalaran.Infrastructure.CustomAttributes
{
    public class LoggedUsersAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return false;
            }

            try
            {
                string userData = FormsAuthentication.Decrypt(cookie.Value).UserData;
            }catch(ArgumentException){
                return false;
            }

            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                filterContext.Result = new HttpStatusCodeResult(401);
                return;
            }
                
            try
            {
                string userData = FormsAuthentication.Decrypt(cookie.Value).UserData;
            }catch(ArgumentException){
                filterContext.Result = new HttpStatusCodeResult(401);
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}