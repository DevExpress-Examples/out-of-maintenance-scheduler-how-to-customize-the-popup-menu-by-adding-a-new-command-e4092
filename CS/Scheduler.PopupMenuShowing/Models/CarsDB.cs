using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using DevExpress.Web.Mvc;

namespace Scheduler.PopupMenuShowing.Models {
    public static class CarsDBDataProvider {
        const string CarsDBDataContextKey = "DXNorthwindDataContext";

        public static CarsDBDataContext DB {
            get {
                if (HttpContext.Current.Items[CarsDBDataContextKey] == null)
                    HttpContext.Current.Items[CarsDBDataContextKey] = new CarsDBDataContext();
                return (CarsDBDataContext)HttpContext.Current.Items[CarsDBDataContextKey];
            }
        }
        public static IEnumerable GetCars() {
            return from car in DB.Cars where car.ID < 6 select new { ID = car.ID, Model = car.Model };
        }
        public static IEnumerable GetCarSchedulings() {
            return from schedule in DB.CarSchedulings select schedule;
        }
 
    }

    public class SchedulerDataObject {
        public IEnumerable Appointments { get; set; }
        public IEnumerable Resources { get; set; }
    }

    public class SchedulerHelper {
        static MVCxAppointmentStorage appointmentStorage;
        public static MVCxAppointmentStorage AppointmentStorage {
            get {
                if (appointmentStorage == null)
                    appointmentStorage = CreateAppointmentStorage();
                return appointmentStorage;
            }
        }

        static MVCxAppointmentStorage CreateAppointmentStorage() {
            MVCxAppointmentStorage appointmentStorage = new MVCxAppointmentStorage();
            appointmentStorage.Mappings.AppointmentId = "ID";
            appointmentStorage.Mappings.Start = "StartTime";
            appointmentStorage.Mappings.End = "EndTime";
            appointmentStorage.Mappings.Subject = "Subject";
            appointmentStorage.Mappings.Description = "Description";
            appointmentStorage.Mappings.Location = "Location";
            appointmentStorage.Mappings.AllDay = "AllDay";
            appointmentStorage.Mappings.Type = "EventType";
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo";
            appointmentStorage.Mappings.Label = "Label";
            appointmentStorage.Mappings.Status = "Status";
            appointmentStorage.Mappings.ResourceId = "CarId";
            return appointmentStorage;
        }

        static MVCxResourceStorage resourceStorage;
        public static MVCxResourceStorage ResourceStorage {
            get {
                if (resourceStorage == null)
                    resourceStorage = CreateResourceStorage();
                return resourceStorage;
            }
        }
        static MVCxResourceStorage CreateResourceStorage() {
            MVCxResourceStorage resourceStorage = new MVCxResourceStorage();
            resourceStorage.Mappings.ResourceId = "ID";
            resourceStorage.Mappings.Caption = "Model";
            return resourceStorage;
        }

        public static SchedulerDataObject DataObject {
            get {
                return new SchedulerDataObject() {
                    Appointments = CarsDBDataProvider.GetCarSchedulings(),
                    Resources = CarsDBDataProvider.GetCars()
                };
            }
        }
    }
}