// Car.cs
namespace RaceGame
{
    public class Car
    {
        public string Model { get; set; }
        public double Speed { get; set; }
        public Driver Driver { get; set; }

        public Car(string model, double speed)
        {
            Model = model;
            Speed = speed;
        }

        public double CalculateSpeed()
        {
            return Driver != null ? Speed * Driver.Skill : 0;
        }
    }
}