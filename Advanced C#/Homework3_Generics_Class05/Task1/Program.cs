using Task1.Models;

PrintInConsole printer = new PrintInConsole();

//single values
printer.Print<int>(7);
printer.Print<string>("Ten");
printer.Print<double>(3.14);

Console.WriteLine();

//collections
List<int> integers = new List<int>()
{
    1,2,3,4,5,6,7
};

printer.PrintCollection(integers);

Console.WriteLine();

List<string> names = new List<string>()
{
   "Marija",
   "Alex",
   "Sara",
   "Leo",
   "Teo",
   "Lui"
};

printer.PrintCollection(names);