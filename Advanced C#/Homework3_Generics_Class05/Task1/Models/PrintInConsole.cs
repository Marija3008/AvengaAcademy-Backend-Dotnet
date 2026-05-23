namespace Task1.Models
{
    public class PrintInConsole
    {
        //generic method for single value
        public void Print<T>(T item) 
        { 
             Console.WriteLine(item);
        }

        //generic method for collections
        public void PrintCollection<T>(List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
