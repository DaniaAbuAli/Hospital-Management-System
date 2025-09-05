using Hospital_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class BillingManagement
    {
        private readonly HospitalDBContext context;

        public BillingManagement()
        {
            context = new HospitalDBContext();
        }

        public void ViewBills()
        {
            var bills = context.Bills.ToList();
            if (!bills.Any()) Console.WriteLine("No bills found");
            else
            {
                foreach (var bill in bills)
                {
                    Console.WriteLine($"Bill Id:{bill.BillId}, Bill Amount:{bill.Amount}, Bill status:{bill.Status}");
                }
            }
        }
        public void AddBills(Bill bill)
        {
            bill.BillDate = DateTime.Now;   
            context.Bills.Add(bill);
            context.SaveChanges();
        }
    }
}
