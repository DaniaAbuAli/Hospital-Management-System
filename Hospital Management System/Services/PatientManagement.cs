using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class PatientManagement
    {
        private readonly HospitalDBContext context;
        public PatientManagement()
        {
            context = new HospitalDBContext();
        }
        public void AddPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }
        public void ViewPatients()
        {
            var patients = context.Patients.ToList();
            if (!patients.Any()) Console.WriteLine("No patients found");
            else
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine($"Id:{patient.PatientId}, Name:{patient.Name}, Age:{patient.Age}, Gender:{patient.Gender}, Contact Number:{patient.ContactNumber}, Address:{patient.Address}");
                }
            }
        }
        public void UpdatePatient(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null)
            {
                Console.WriteLine("This patient does not exist, please try again.");
            }
            else
            {
                string[] options = { "Name", "Age", "Gender", "Contact Number", "Address" };
                Console.WriteLine("Please select what you want to update:");
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }
                string selectedOption = Console.ReadLine();
                Console.WriteLine($"Enter the new {selectedOption} :");
                var value = Console.ReadLine();
                switch (selectedOption.Trim().ToLower())
                {
                    case "name": patient.Name = value; break;
                    case "age":
                        if (int.TryParse(value, out int age))
                            patient.Age = age;
                        else
                            Console.WriteLine("Invalid input! Age must be a number.");
                        break;

                    case "gender": patient.Gender = value; break;
                    case "contact number": patient.ContactNumber = value; break;
                    case "address": patient.Address = value; break;
                }
                context.SaveChanges();

            }
        }
        public void DeletePatient(int id)
        {
            var patient = context.Patients.Find(id);
            if (patient == null) Console.WriteLine("This patient does not exist, please try again.");
            else
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
        }

    }
}
