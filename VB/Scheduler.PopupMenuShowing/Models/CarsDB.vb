Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections
Imports DevExpress.Web.Mvc

Namespace Scheduler.PopupMenuShowing.Models
	Public NotInheritable Class CarsDBDataProvider
		Private Const CarsDBDataContextKey As String = "DXNorthwindDataContext"

		Private Sub New()
		End Sub
		Public Shared ReadOnly Property DB() As CarsDBDataContext
			Get
				If HttpContext.Current.Items(CarsDBDataContextKey) Is Nothing Then
					HttpContext.Current.Items(CarsDBDataContextKey) = New CarsDBDataContext()
				End If
				Return CType(HttpContext.Current.Items(CarsDBDataContextKey), CarsDBDataContext)
			End Get
		End Property
		Public Shared Function GetCars() As IEnumerable
			Return _
				From car In DB.Cars _
				Where car.ID < 6 _
				Select New With {Key .ID = car.ID, Key .Model = car.Model}
		End Function
		Public Shared Function GetCarSchedulings() As IEnumerable
			Return _
				From schedule In DB.CarSchedulings _
				Select schedule
		End Function

	End Class

	Public Class SchedulerDataObject
		Private privateAppointments As IEnumerable
		Public Property Appointments() As IEnumerable
			Get
				Return privateAppointments
			End Get
			Set(ByVal value As IEnumerable)
				privateAppointments = value
			End Set
		End Property
		Private privateResources As IEnumerable
		Public Property Resources() As IEnumerable
			Get
				Return privateResources
			End Get
			Set(ByVal value As IEnumerable)
				privateResources = value
			End Set
		End Property
	End Class

	Public Class SchedulerHelper
		Private Shared appointmentStorage_Renamed As MVCxAppointmentStorage
		Public Shared ReadOnly Property AppointmentStorage() As MVCxAppointmentStorage
			Get
				If appointmentStorage_Renamed Is Nothing Then
					appointmentStorage_Renamed = CreateAppointmentStorage()
				End If
				Return appointmentStorage_Renamed
			End Get
		End Property

		Private Shared Function CreateAppointmentStorage() As MVCxAppointmentStorage
			Dim appointmentStorage As New MVCxAppointmentStorage()
			appointmentStorage.Mappings.AppointmentId = "ID"
			appointmentStorage.Mappings.Start = "StartTime"
			appointmentStorage.Mappings.End = "EndTime"
			appointmentStorage.Mappings.Subject = "Subject"
			appointmentStorage.Mappings.Description = "Description"
			appointmentStorage.Mappings.Location = "Location"
			appointmentStorage.Mappings.AllDay = "AllDay"
			appointmentStorage.Mappings.Type = "EventType"
			appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
			appointmentStorage.Mappings.Label = "Label"
			appointmentStorage.Mappings.Status = "Status"
			appointmentStorage.Mappings.ResourceId = "CarId"
			Return appointmentStorage
		End Function

		Private Shared resourceStorage_Renamed As MVCxResourceStorage
		Public Shared ReadOnly Property ResourceStorage() As MVCxResourceStorage
			Get
				If resourceStorage_Renamed Is Nothing Then
					resourceStorage_Renamed = CreateResourceStorage()
				End If
				Return resourceStorage_Renamed
			End Get
		End Property
		Private Shared Function CreateResourceStorage() As MVCxResourceStorage
			Dim resourceStorage As New MVCxResourceStorage()
			resourceStorage.Mappings.ResourceId = "ID"
			resourceStorage.Mappings.Caption = "Model"
			Return resourceStorage
		End Function

		Public Shared ReadOnly Property DataObject() As SchedulerDataObject
			Get
				Return New SchedulerDataObject() With {.Appointments = CarsDBDataProvider.GetCarSchedulings(), .Resources = CarsDBDataProvider.GetCars()}
			End Get
		End Property
	End Class
End Namespace