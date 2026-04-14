using System;
using System.Collections.Generic;

Queue<int> numbersQueue = new Queue<int>();

string choice = "Y";

while (choice.ToUpper() == "Y")
{
    Console.Write("Enter a number: ");
    int number = int.Parse(Console.ReadLine());

    numbersQueue.Enqueue(number);

    Console.Write("Do you want to enter another number? (Y/N): ");
    choice = Console.ReadLine();
}

Console.WriteLine("\nNumbers in the order you entered:");

foreach (int num in numbersQueue)
{
    Console.WriteLine(num);
}