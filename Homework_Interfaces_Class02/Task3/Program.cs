using Task3.Models;

Circle circle = new Circle(5);
Triangle triangle = new Triangle(7, 5, 4, 3.4);

Console.WriteLine("Circle Area: " + circle.CalculateArea());
Console.WriteLine("Circle Perimeter: " + circle.CalculatePerimetar());

Console.WriteLine();

Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
Console.WriteLine("Triangle Perimeter: " + triangle.CalculatePerimetar());