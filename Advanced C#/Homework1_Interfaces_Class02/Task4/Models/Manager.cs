namespace Task4.Models
{
    internal class Manager : Employee
    {
        private int hoursWorked;
        private double hourlyRate;

        public Manager() { }
        
        public Manager(string name, int hoursWorked, double hourlyRate) : base(name)
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
            Console.WriteLine("Manager Name: " + Name);
            Console.WriteLine("Salary: " + CalculateSalary());
        }
    }
}
