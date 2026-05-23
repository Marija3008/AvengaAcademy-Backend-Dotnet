//1. all cars from europe
using Task1.Models;

List<Car> europeanCars = CarsData.Cars
    .Where(car => car.Origin == "Europe")
    .ToList();

foreach (Car car in europeanCars)
{
    Console.WriteLine(car.Model);
}

Console.WriteLine();

// 2.1 cars with more than 6 cylinders
List<Car> moreThan6Cylinders = CarsData.Cars
    .Where(car => car.Cylinders > 6)
    .ToList();

// 2.2 cars with exactly 4 cylinders and horsepower > 110
List<Car> fourCylindersMoreHp = CarsData.Cars
    .Where(car => car.Cylinders == 4 && car.HorsePower > 110)
    .ToList();

//2.1 and 2.2 joined
List<Car> joinedCars = moreThan6Cylinders
    .Concat(fourCylindersMoreHp)
    .ToList();

foreach (Car car in joinedCars)
{
    Console.WriteLine($"{car.Model} - Cylinders: {car.Cylinders} - HP: {car.HorsePower}");
}

Console.WriteLine();

// 3. count cars by origin
Console.WriteLine("Cars grouped by origin:");

var groupedCars = CarsData.Cars
    .GroupBy(car => car.Origin);

foreach (var group in groupedCars)
{
    Console.WriteLine($"{group.Key} {group.Count()} models");
}

Console.WriteLine();

// 4. cars with more than 200 horsepower
List<Car> powerfulCars = CarsData.Cars
    .Where(car => car.HorsePower > 200)
    .ToList();

double minMpg = powerfulCars.Min(car => car.MilesPerGalon);
double maxMpg = powerfulCars.Max(car => car.MilesPerGalon);
double avgMpg = powerfulCars.Average(car => car.MilesPerGalon);

Console.WriteLine("Cars with more than 200 HP:");
Console.WriteLine($"Lowest MPG: {minMpg}");
Console.WriteLine($"Highest MPG: {maxMpg}");
Console.WriteLine($"Average MPG: {avgMpg}");

Console.WriteLine();


//additional examples

//5. avg horsepower
double averageHorsePower = CarsData.Cars
            .Average(car => car.HorsePower);

Console.WriteLine($"Average HorsePower: {averageHorsePower}");

Console.WriteLine();

//6. heaviest car
Car heaviestCar = CarsData.Cars
    .OrderByDescending(car => car.Weight)
    .First();

Console.WriteLine("Heaviest car:");
Console.WriteLine($"{heaviestCar.Model} - {heaviestCar.Weight}");

Console.WriteLine();

//7. fastest acceleration
Car fastestCar = CarsData.Cars
    .OrderBy(car => car.AccelerationTime)
    .First();

Console.WriteLine("Fastest acceleration:");
Console.WriteLine($"{fastestCar.Model} - {fastestCar.AccelerationTime}");