namespace Task3.Models
{
    public class Triangle : Shape
    {
        public double BaseSide;
        public double SideB, SideC;
        public double Height;

        public Triangle() { }

        public Triangle(double baseSide,double sideB, double sideC, double height)
        {
            BaseSide = baseSide;
            SideB = sideB;
            SideC = sideC;
            Height = height;
        }
        public override double CalculateArea()
        {
            return (BaseSide * Height) / 2;
        }

        public override double CalculatePerimetar()
        {
            return BaseSide + SideB + SideC;
        }
    }
}
