Console.WriteLine("Swap Numbers");

double firstNumber;
Console.WriteLine("Input the First Number:");
while (!double.TryParse(Console.ReadLine(), out firstNumber))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double secondNumber;
Console.WriteLine("Input the Second Number:");
while (!double.TryParse(Console.ReadLine(), out secondNumber))
{
    Console.WriteLine("Invalid input! Enter a valid number:");
}

double temp = firstNumber;
firstNumber = secondNumber;
secondNumber = temp;

Console.WriteLine("After Swapping:");
Console.WriteLine($"First Number: {firstNumber}");
Console.WriteLine($"Second Number: {secondNumber}");