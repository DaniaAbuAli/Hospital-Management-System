using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entities
{
    public enum Status
    {
        Scheduled, Completed, Canceled
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public Status Status { get; set; } = Status.Scheduled;

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
