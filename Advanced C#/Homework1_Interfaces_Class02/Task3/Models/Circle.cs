namespace Task3.Models
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle() { }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double CalculatePerimetar()
        {
            return Math.PI * Radius * 2;
        }
    }
}
