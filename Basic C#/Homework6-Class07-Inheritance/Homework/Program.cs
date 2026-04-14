using Domain.Models;
using Domain.Enums;

Developer dev1 = new Developer(
    1, "Bob", "Bobsky", 30, 5000, Seniority.Junior, "C#"
);

Developer dev2 = new Developer(
    2, "John", "Johnsky", 28, 6000, Seniority.Mid, "Java"
);

Manager manager1 = new Manager(
    3, "Alice", "Manager", 35, 7000, Seniority.Senior, "IT"
);

Manager manager2 = new Manager(
    4, "Mark", "Boss", 40, 7500, Seniority.Senior, "HR"
);

Contractor contractor = new Contractor(
    5, "Contract", "Guy", 32, 0, Seniority.Junior
)
{
    WorkHours = 160,
    PayPerHour = 50,
    Responsible = manager1
};

CEO ceo = new CEO(
    6, "Big", "Boss", 50, 8000, Seniority.Senior
)
{
    Shares = 100,
    Employees = new Employee[]
    {
        dev1, dev2, manager1, manager2, contractor
    }
};

ceo.UpdateSharesPrice(50);

// OUTPUT
Console.WriteLine(ceo.GetDetails());

Console.WriteLine("\nEmployees:");
ceo.PrintEmployees();

Console.WriteLine($"\nCEO Annual Bonus: {ceo.CalculateAnnualBonus():F2}");