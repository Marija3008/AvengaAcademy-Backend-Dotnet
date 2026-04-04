using System;
using RaceGame;

Driver[] drivers = new Driver[]
{
    new Driver("Bob", 1.2),
    new Driver("Greg", 1.1),
    new Driver("Jill", 1.3),
    new Driver("Anne", 1.0)
};

// Create cars (array)
Car[] cars = new Car[]
{
    new Car("Hyundai", 120),
    new Car("Mazda", 130),
    new Car("Ferrari", 200),
    new Car("Porsche", 220)
};

bool raceAgain = true;

while (raceAgain)
{
    Console.WriteLine("Select Car 1:");
    int car1Index = SelectCar(cars);
    Console.WriteLine("Select Driver for Car 1:");
    int driver1Index = SelectDriver(drivers);

    cars[car1Index].Driver = drivers[driver1Index];

    Console.WriteLine("\nSelect Car 2:");
    int car2Index = SelectCar(cars, car1Index);
    Console.WriteLine("Select Driver for Car 2:");
    int driver2Index = SelectDriver(drivers, driver1Index);
    cars[car2Index].Driver = drivers[driver2Index];

    RaceCars(cars[car1Index], cars[car2Index]);

    Console.WriteLine("\nDo you want to race again? (y/n):");
    raceAgain = Console.ReadLine().Trim().ToLower() == "y";
}



int SelectCar(Car[] cars, int excludeIndex = -1)
{
    for (int i = 0; i < cars.Length; i++)
        if (i != excludeIndex)
            Console.WriteLine($"{i + 1}. {cars[i].Model}");

    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > cars.Length || choice - 1 == excludeIndex)
        Console.WriteLine("Invalid choice, try again:");

    return choice - 1;
}

int SelectDriver(Driver[] drivers, int excludeIndex = -1)
{
    for (int i = 0; i < drivers.Length; i++)
        if (i != excludeIndex)
            Console.WriteLine($"{i + 1}. {drivers[i].Name}");

    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > drivers.Length || choice - 1 == excludeIndex)
        Console.WriteLine("Invalid choice, try again:");

    return choice - 1;
}

void RaceCars(Car car1, Car car2)
{
    double speed1 = car1.CalculateSpeed();
    double speed2 = car2.CalculateSpeed();

    Console.WriteLine("\n--- Race Results ---");
    if (speed1 > speed2)
        Console.WriteLine($"Car {car1.Model} driven by {car1.Driver.Name} was faster! Speed: {speed1} km/h");
    else if (speed2 > speed1)
        Console.WriteLine($"Car {car2.Model} driven by {car2.Driver.Name} was faster! Speed: {speed2} km/h");
    else
        Console.WriteLine("It's a tie!");
}