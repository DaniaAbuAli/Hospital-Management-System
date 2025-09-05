using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class PrescriptionManagement
    {
        private readonly HospitalDBContext context;

        public PrescriptionManagement()
        {
            context = new HospitalDBContext();
        }
        public void IssuePrescription(Prescription prescription)
        {
            prescription.PrescriptionDate = DateTime.Now;
            context.Prescriptions.Add(prescription);
            context.SaveChanges();
        }
        public void ViewPrescriptions()
        {
            var prescriptions = context.Prescriptions.ToList();
            if (!prescriptions.Any()) Console.WriteLine("No prescriptions found");
            else
            {
                foreach (var prescription in prescriptions)
                {
                    Console.WriteLine($"prescription ID:{prescription.PrescriptionId}, Doctor ID:{prescription.DoctorId}, Prescription Date:{prescription.PrescriptionDate}, patient Id:{prescription.PatientId}");
                }
            }
        }
    }
}
