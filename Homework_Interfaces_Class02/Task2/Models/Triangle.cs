using Task2.Interfaces;

namespace Task2.Models
{
    public class Triangle : IShape
    {
        public double BaseSideLength { get; set; }
        public double Height { get; set; }

        public Triangle() { }

        public Triangle(double baseSideLength, double height) 
        {
            BaseSideLength = baseSideLength;
            Height = height;
        }
        public double GetArea()
        {
            return (BaseSideLength*Height)/2;
        }
    }
}
