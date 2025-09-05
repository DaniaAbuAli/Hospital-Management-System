using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class DoctorManagement
    {
        private readonly HospitalDBContext context;

        public DoctorManagement()
        {
            context = new HospitalDBContext();
        }
        public void AddDoctor(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            context.SaveChanges();

        }
        public void ViewDoctors()
        {
            var doctors = context.Doctors.ToList();
            if (!doctors.Any()) Console.WriteLine("No doctors found");
            else
            {
                foreach (var doctor in doctors)
                {
                    Console.WriteLine($"Id:{doctor.DoctorId}, Name:{doctor.Name}, Age:{doctor.Age}, Gender:{doctor.Gender}, Contact Number:{doctor.ContactNumber}, Email:{doctor.Email}, Specialty:{doctor.Specialty} ");
                }
            }
        }
        public void UpdateDoctor(int id)
        {
            var doctor = context.Doctors.Find(id);
            if (doctor == null)
            {
                Console.WriteLine("This doctor does not exist, please try again.");
            }
            else
            {
                string[] options = { "Name", "Age", "Gender", "Contact Number", "Email", "Specialty" };
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
                    case "name": doctor.Name = value; break;
                    case "age":
                        if (int.TryParse(value, out int age))
                            doctor.Age = age;
                        else
                            Console.WriteLine("Invalid input! Age must be a number.");
                        break;

                    case "gender": doctor.Gender = value; break;
                    case "contact number": doctor.ContactNumber = value; break;
                    case "email": doctor.Email = value; break;
                    case "specialty": doctor.Specialty = value; break;
                }
                context.SaveChanges();

            }
        }

        public void DeleteDoctor(int id)
        {
            var doctor = context.Doctors.Find(id);
            if (doctor == null) Console.WriteLine("This doctor does not exist, please try again.");
            else
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
        }

    }
}
