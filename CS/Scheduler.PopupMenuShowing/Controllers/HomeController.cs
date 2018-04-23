using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduler.PopupMenuShowing.Models;
using DevExpress.Web.Mvc;

namespace Scheduler.PopupMenuShowing.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
            return View(SchedulerHelper.DataObject);
        }
        public ActionResult SchedulerPartial() {
            return PartialView("SchedulerPartial", SchedulerHelper.DataObject);
        }
        public ActionResult ResourceInfoPartial() {
            return PartialView(SchedulerHelper.DataObject.Resources);
        }
    }
}