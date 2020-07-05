using Nagarro.Training.MVC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nagarro.Training.MVC.BookReadingEvent.Controllers
{
    public class NagarroHelpDeskController : Controller
    {
        public void Home()
        {
            Response.Redirect(Resource.CustomRoute, true);
        }
    }
}