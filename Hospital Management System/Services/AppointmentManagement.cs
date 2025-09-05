using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hospital_Management_System.Services
{
    public class AppointmentManagement
    {
        private readonly HospitalDBContext context;
        public AppointmentManagement()
        {
            context = new HospitalDBContext();
        }
        public void ScheduleAppointment(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
        }
        public void ViewAppointments()
        {
            var appointments = context.Appointments.ToList();
            if (!appointments.Any()) Console.WriteLine("No appointments found");
            else
            {
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Patient ID:{appointment.PatientId}, Doctor ID:{appointment.DoctorId}, Appointment Date:{appointment.AppointmentDate}, Status:{appointment.Status}");
                }
            }
        }
        public void CancelAppointment(int appointmentId)
        {
            var appointment = context.Appointments.Find(appointmentId);
            if (appointment == null) Console.WriteLine("This appointment does not exist, please try again.");
            else
            {
                appointment.Status = Status.Canceled;
                Console.WriteLine("The appointment has been successfully canceled.");
                context.SaveChanges();
            }

        }
    }
}
