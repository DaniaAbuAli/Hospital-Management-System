using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class MedicationManagement
    {
        private readonly HospitalDBContext context;
        public MedicationManagement()
        {
            context = new HospitalDBContext();
        }
        public void AddMedication(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
        }
        public void ViewMedications()
        {
            var medications = context.Medications.ToList();
            if (!medications.Any()) Console.WriteLine("No medications found");
            else
            {
                foreach (var medication in medications)
                {
                    Console.WriteLine($"Id:{medication.MedicationId}, Name:{medication.Name}, Price:{medication.Price}, Quantity:{medication.Quantity} ");
                }
            }
        }
        public decimal CalculateAmount(List<int> medicationids)
        {
            decimal amount = 0;
            foreach (var id in medicationids)
            {
                var medication = context.Medications.Find(id);
                amount += medication.Price;
                medication.Quantity -= 1;
            }
            context.SaveChanges();
            return amount;
        }
    }
}
