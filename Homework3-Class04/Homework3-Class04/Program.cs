using System;
using System.Globalization;

DateTime birthDate = DateTime.MinValue;
bool isValid = false;

while (!isValid)
{
    Console.Write("Enter your birth date (dd/MM/yyyy): ");
    string input = Console.ReadLine();

    isValid = DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);

    if (!isValid)
    {
        Console.WriteLine("Invalid format! Try again!");
    }
}

//AgeCalculator function
static int AgeCalculator(DateTime bDate)
{
    DateTime today = DateTime.Now;

    int age = today.Year - bDate.Year;

    DateTime nextBirthday = new DateTime(today.Year, bDate.Month, bDate.Day);

    if (today.Month == bDate.Month && today.Day == bDate.Day)
    {
        Console.WriteLine($"Happy Birthday! You are celebrating your {age} birthday.");
    }
    else if (today < nextBirthday)
    {
        age--;

        TimeSpan daysLeft = nextBirthday - today;
        Console.WriteLine($"Your birthday is coming! {daysLeft.Days} days left.");
    }
    else
    {
        TimeSpan daysPassed = today - nextBirthday;
        Console.WriteLine($"Your birthday already passed {daysPassed.Days} days ago.");
    }

    return age;
}

Console.WriteLine($"You are {AgeCalculator(birthDate)} years old.");

