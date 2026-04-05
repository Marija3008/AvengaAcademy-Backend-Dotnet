using Domain.Enums;

namespace Domain.Models
{
    public class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(
            int id,
            string firstName,
            string lastName,
            int age,
            double salary,
            Seniority seniority,
            string programmingLanguage)
            // : base(...) calls the constructor of the base class (Employee) to initialize the common properties
            : base(id, firstName, lastName, age, salary, seniority)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        // Here we override the virtual method from the parent class with new implementation (specific for the Developer class)
        public override string GetDetails()
        {
            // base.GetDetails() calls the GetDetails method of the base class (Employee) to get the common details, then we append the programming language info
            return $"{base.GetDetails()}, Programming Language: {ProgrammingLanguage}";
        }

        public override double CalculateAnnualBonus()
        {
            return Salary * 0.3;
        }

        public string GetSalary()
        {
            return Salary.ToString("C");
        }
    }
}
