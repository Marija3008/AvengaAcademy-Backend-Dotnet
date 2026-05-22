namespace Task4.Models
{
    public class Programmer : Employee
    {
        private int hoursWorked;
        private double hourlyRate;

        public Programmer() { }

        public Programmer(string name, int hoursWorked, double hourlyRate): base(name)
        {
            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
        }
        public override double CalculateSalary()
        {
            return hoursWorked * hourlyRate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Programmer Name: " + Name);
            Console.WriteLine("Salary: " + CalculateSalary());
        }
    }
}
