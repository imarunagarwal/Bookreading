using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Nagarro.Training.MVC.BookReadingEvent.Filters
{
    public class AuthenticateFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var UserID = filterContext.HttpContext.Session["UserID"];
            //For Allowing Anonymous
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any())
            {
                return;
            }
            if (UserID == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };
            }

        }
    }
}