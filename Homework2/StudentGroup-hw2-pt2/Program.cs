Console.WriteLine("Student Groups");


string[] studentsG1 = { "Anisija", "Miki", "Mira", "Ivana", "Trajko" };
string[] studentsG2 = { "Kiki", "Marija", "Elena", "Ace", "Sara" };


int groupNumber;
Console.WriteLine("Enter student group (1 or 2):");

while (!int.TryParse(Console.ReadLine(), out groupNumber) || (groupNumber != 1 && groupNumber != 2))
{
    Console.WriteLine("Invalid input! Please enter 1 or 2:");
}


if (groupNumber == 1)
{
    Console.WriteLine("The Students in G1 are:");
    foreach (string student in studentsG1)
    {
        Console.WriteLine(student);
    }
}
else
{
    Console.WriteLine("The Students in G2 are:");
    foreach (string student in studentsG2)
    {
        Console.WriteLine(student);
    }
}