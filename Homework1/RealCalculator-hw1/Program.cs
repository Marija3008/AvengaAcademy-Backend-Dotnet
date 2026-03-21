Console.WriteLine("Real Calculator");

double firstNumber;
while (true) //allows entering a value till the conditions is fullfilled
{
    Console.WriteLine("Enter the First number:");

    if (double.TryParse(Console.ReadLine(), out firstNumber))
    {
        break;
    }

    Console.WriteLine("Invalid input! Please enter a valid number.");
}


double secondNumber;
while (true)
{
    Console.WriteLine("Enter the Second number:");

    if (double.TryParse(Console.ReadLine(), out secondNumber))
    {
        break;
    }

    Console.WriteLine("Invalid input! Please enter a valid number.");
}


Console.WriteLine("Enter the Operation (+, -, *, /):");
string operation = Console.ReadLine();


switch (operation)
{
    case "+":
        double sum = firstNumber + secondNumber;
        Console.WriteLine($"The sum of {firstNumber} and {secondNumber} is: {sum}");
        break;

    case "-":
        double dif = firstNumber - secondNumber;
        Console.WriteLine($"The difference of {firstNumber} - {secondNumber} is: {dif}");
        break;

    case "*":
        double multiplication = firstNumber * secondNumber;
        Console.WriteLine($"The multiplication of {firstNumber} and {secondNumber} is: {multiplication}");
        break;

    case "/":
        if (secondNumber != 0)
        {
            double division = firstNumber / secondNumber;
            Console.WriteLine($"The division of {firstNumber} by {secondNumber} is: {division}");
        }
        else
        {
            Console.WriteLine("Division by 0 is not possible!");
        }
        break;

    default:
        Console.WriteLine("You entered invalid operator!");
        break;
}