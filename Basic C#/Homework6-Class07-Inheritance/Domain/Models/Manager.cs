using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Manager : Employee
    {
        public string Department { get; set; }

        public Manager(
            int id,
            string firstName,
            string lastName,
            int age,
            double salary,
            Seniority seniority,
            string department)
            : base(id, firstName, lastName, age, salary, seniority)
        {
            Department = department;
        }

        public override string ToString()
        {
            return $"Manager {FirstName} {LastName}";
        }
    }
}
