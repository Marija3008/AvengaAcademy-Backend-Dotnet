namespace RaceGame
{
    public class Driver
    {
        public string Name { get; set; }
        public double Skill { get; set; }

        public Driver(string name, double skill)
        {
            Name = name;
            Skill = skill;
        }
    }
}