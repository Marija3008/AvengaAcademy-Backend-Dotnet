Console.WriteLine("Sum Of Even Numbers");

int[] numbers = new int[6];

for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"Enter integer no.{i + 1}:");

    while (!int.TryParse(Console.ReadLine(), out numbers[i]))
    {
        Console.WriteLine("Invalid input! Enter a valid integer:");
    }
}

int sum = 0;

foreach (int num in numbers)
{
    if (num % 2 == 0)
    {
        sum += num;
    }
}

Console.WriteLine($"The result is: {sum}");