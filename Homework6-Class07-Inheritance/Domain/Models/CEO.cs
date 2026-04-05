using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CEO : Employee
    {
        public Employee[] Employees { get; set; }
        public int Shares { get; set; }

        public double SharesPrice { get; private set; }

        public CEO(
            int id,
            string firstName,
            string lastName,
            int age,
            double salary,
            Seniority seniority)
            : base(id, firstName, lastName, age, salary, seniority)
        {
        }

        public void UpdateSharesPrice(double amount)
        {
            SharesPrice = amount;
        }

        public void PrintEmployees()
        {
            foreach (Employee employee in Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
        }

        public override double CalculateAnnualBonus()
        {
            return base.CalculateAnnualBonus() + (Shares * SharesPrice);
        }
    }
}