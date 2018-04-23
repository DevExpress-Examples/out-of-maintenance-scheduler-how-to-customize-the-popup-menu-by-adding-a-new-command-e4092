Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports Scheduler.PopupMenuShowing.Models
Imports DevExpress.Web.Mvc

Namespace Scheduler.PopupMenuShowing.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"
			Return View(SchedulerHelper.DataObject)
		End Function
		Public Function SchedulerPartial() As ActionResult
			Return PartialView("SchedulerPartial", SchedulerHelper.DataObject)
		End Function
		Public Function ResourceInfoPartial() As ActionResult
			Return PartialView(SchedulerHelper.DataObject.Resources)
		End Function
	End Class
End Namespace