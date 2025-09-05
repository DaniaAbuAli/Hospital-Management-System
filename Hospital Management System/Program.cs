using Hospital_Management_System.Entities;
using Hospital_Management_System.Services;

public class Program
{
    private static void Main(string[] args)
    {
        bool exit = false;
        PatientManagement patientManagement = new PatientManagement();
        DoctorManagement doctorManagement = new DoctorManagement();
        AppointmentManagement appointmentManagement = new AppointmentManagement();
        PrescriptionManagement prescriptionManagement = new PrescriptionManagement();
        MedicationManagement medicationManagement = new MedicationManagement();
        BillingManagement billingManagement = new BillingManagement();
        string[] mainOptions = { "Patient Management", "Doctor Management", "Appointment Management", "Prescription Management", "Medication Management", "Billing Management", "Exit" };
        while (!exit)
        {
            Console.WriteLine("Please select one of the following main options by entering its number:");
            for (int i = 0; i < mainOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {mainOptions[i]}");
            }
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Patient Management - Please select an option by entering its number:");
                    Console.WriteLine("1. Add Patient");
                    Console.WriteLine("2. View Patients");
                    Console.WriteLine("3. Update Patient");
                    Console.WriteLine("4. Delete Patient");
                    var number = Console.ReadLine();
                    switch (number)
                    {

                        case "1":
                            Console.WriteLine("Please enter patient details:");
                            Console.Write("Name:");
                            string name = Console.ReadLine();
                            Console.Write("Age:");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("Gender:");
                            string gender = Console.ReadLine();
                            Console.Write("Contact Number:");
                            string contactNumber = Console.ReadLine();
                            Console.Write("Address:");
                            string address = Console.ReadLine();
                            var patient = new Patient() { Name = name, Age = age, Gender = gender, ContactNumber = contactNumber, Address = address };
                            patientManagement.AddPatient(patient);
                            break;
                        case "2":
                            Console.WriteLine("Patients in the system:");
                            patientManagement.ViewPatients();
                            break;
                        case "3":
                            Console.WriteLine("Please enter the ID of the patient to update:");
                            int id = int.Parse(Console.ReadLine());
                            patientManagement.UpdatePatient(id);
                            break;
                        case "4":
                            Console.WriteLine("Please enter the ID of the patient to delete:");
                            id = int.Parse(Console.ReadLine());
                            patientManagement.DeletePatient(id);
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Doctor Management - Please select an option by entering its number:");
                    Console.WriteLine("1. Add Doctor");
                    Console.WriteLine("2. View Doctors");
                    Console.WriteLine("3. Update Doctor");
                    Console.WriteLine("4. Delete Doctors");
                    number = Console.ReadLine();
                    switch (number)
                    {

                        case "1":
                            Console.WriteLine("Please enter doctor details:");
                            Console.Write("Name:");
                            string name = Console.ReadLine();
                            Console.Write("Age:");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("Gender:");
                            string gender = Console.ReadLine();
                            Console.Write("Contact Number:");
                            string contactNumber = Console.ReadLine();
                            Console.Write("Email:");
                            string email = Console.ReadLine();
                            Console.Write("Specialty:");
                            string specialty = Console.ReadLine();
                            var doctor = new Doctor() { Name = name, Age = age, Gender = gender, ContactNumber = contactNumber, Email = email, Specialty = specialty };
                            doctorManagement.AddDoctor(doctor);
                            break;

                        case "2":
                            Console.WriteLine("Doctors in the system:");
                            doctorManagement.ViewDoctors();
                            break;
                        case "3":
                            Console.WriteLine("Please enter the ID of the doctor to update:");
                            int id = int.Parse(Console.ReadLine());
                            doctorManagement.UpdateDoctor(id);
                            break;
                        case "4":
                            Console.WriteLine("Please enter the ID of the doctor to delete:");
                            id = int.Parse(Console.ReadLine());
                            doctorManagement.DeleteDoctor(id);
                            break;
                    }


                    break;
                case "3":
                    Console.WriteLine("Appointment Management - Please select an option by entering its number:");
                    Console.WriteLine("1. Schedule Appointment ");
                    Console.WriteLine("2. View Appointments");
                    Console.WriteLine("3. Cancel Appointment");
                    number = Console.ReadLine();
                    switch (number)
                    {

                        case "1":
                            Console.WriteLine("Please enter appointment details:");
                            Console.Write("Patient ID: ");
                            int patientId = int.Parse(Console.ReadLine());
                            Console.Write("Doctor ID: ");
                            int doctorId = int.Parse(Console.ReadLine());
                            Console.Write("Appointment Date: ");
                            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                            Appointment appointment = new Appointment() { PatientId = patientId, DoctorId = doctorId, AppointmentDate = appointmentDate };
                            appointmentManagement.ScheduleAppointment(appointment);
                            break;
                        case "2":
                            Console.WriteLine("Appointments: ");
                            appointmentManagement.ViewAppointments();
                            break;
                        case "3":
                            Console.WriteLine("Enter the ID of the appointment you would like to cancel:");
                            int id = int.Parse(Console.ReadLine());
                            appointmentManagement.CancelAppointment(id);
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("Prescription Management - Please select an option by entering its number:");
                    Console.WriteLine("1. Issue Prescription");
                    Console.WriteLine("2. View Prescriptions ");
                    number = Console.ReadLine();
                    switch (number)
                    {

                        case "1":
                            Console.WriteLine("Please enter the following information:");
                            Console.Write("Patient ID: ");
                            int patientId = int.Parse(Console.ReadLine());
                            Console.Write("Doctor ID: ");
                            int doctorId = int.Parse(Console.ReadLine());
                            List<int> medicationIds = new List<int>();
                            Console.Write("Medication IDs (enter 0 when done): ");
                            while (true)
                            {
                                Console.WriteLine("Medication Id:");
                                int medicationId = int.Parse(Console.ReadLine());
                                if (medicationId == 0) break;
                                medicationIds.Add(medicationId);

                            }
                            Prescription prescription = new Prescription() { PatientId = patientId, DoctorId = doctorId };
                            prescriptionManagement.IssuePrescription(prescription);
                            decimal amount = medicationManagement.CalculateAmount(medicationIds);
                            Bill bill = new Bill() { Amount = amount, PrescriptionId = prescription.PrescriptionId, Status = "Unpaid" };
                            billingManagement.AddBills(bill);
                            break;
                        case "2":
                            Console.WriteLine("Prescriptions: ");
                            prescriptionManagement.ViewPrescriptions();
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine("Medication Management - Please select an option by entering its number:");
                    Console.WriteLine("1. Add Medication ");
                    Console.WriteLine("2. View Medications ");
                    number = Console.ReadLine();
                    switch (number)
                    {
                        case "1":
                            Console.WriteLine("Please enter the following medication details:");
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("price: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            Console.Write("quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            Medication medication = new Medication() { Name = name, Price = price, Quantity = quantity };
                            medicationManagement.AddMedication(medication);
                            break;
                        case "2":
                            Console.WriteLine("Medications:");
                            medicationManagement.ViewMedications();
                            break;
                    }
                    break;
                case "6":
                    Console.WriteLine("Billing Management - Please select an option by entering its number:");
                    Console.WriteLine("1.View Bills");
                    number = Console.ReadLine();
                    switch (number)
                    {
                        case "1":
                            Console.WriteLine("Bills: ");
                            billingManagement.ViewBills();
                            break;
                    }
                    break;
                case "7": exit = true; break;

            }
        }
    }
}
