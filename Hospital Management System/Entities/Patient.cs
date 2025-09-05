using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }

    }
}
