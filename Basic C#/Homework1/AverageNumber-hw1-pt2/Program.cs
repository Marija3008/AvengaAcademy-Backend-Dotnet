Console.WriteLine("Average Calculator");

double num1;
Console.WriteLine("Enter the First number:");
while (!double.TryParse(Console.ReadLine(), out num1))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double num2;
Console.WriteLine("Enter the Second number:");
while (!double.TryParse(Console.ReadLine(), out num2))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double num3;
Console.WriteLine("Enter the Third number:");
while (!double.TryParse(Console.ReadLine(), out num3))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double num4;
Console.WriteLine("Enter the Fourth number:");
while (!double.TryParse(Console.ReadLine(), out num4))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double average = (num1 + num2 + num3 + num4) / 4;

Console.WriteLine($"The average of {num1}, {num2}, {num3} and {num4} is: {average}");