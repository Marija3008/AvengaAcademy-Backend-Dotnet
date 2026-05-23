using Task1.Models;

//search by id
User userById = UserDatabase.Search(1);

if (userById != null)
{
    Console.WriteLine("Search by id: ");
    userById.DisplayUser();
}

Console.WriteLine();


//search by name
Console.WriteLine("Search by name: ");
string name = Console.ReadLine().ToLower();
//list of users cuz there can be more than one with th esame name
List<User> usersByName = UserDatabase.Search(name.ToLower());

foreach (User user in usersByName)
{
    user.DisplayUser();
}

Console.WriteLine();

//search by age
Console.WriteLine("Search by age: ");
string input = Console.ReadLine();
if (int.TryParse(input, out int age))
{
    //list of users cuz there can be more than one with th esame name
    List<User> usersByAge = UserDatabase.SearchByAge(age);
    foreach (User user in usersByAge)
    {
        user.DisplayUser();
    }
}
else
{
    Console.WriteLine("Invalid input, enter age!");
}
