namespace Task2.Models
{
    internal class Airplane : Vehicle
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Im a plane i have couple of wheels");
        }

        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}
