namespace Task1.Models
{
    public static class UserDatabase
    {
        public static List<User> Users = new List<User>()
        {
            new User(1, "Marija", 22),
            new User(2, "Gordan", 23),
            new User(2, "Alex", 25),
            new User(3, "Marko", 30),
            new User(4, "Sara", 22),
            new User(5, "Sara", 62)

        };

        //search by id
        public static User Search(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);

        }

        //search by name
        public static List<User> Search(string name)
        {
            return Users
                .Where(u => u.Name.ToLower() == name.ToLower())
                .ToList();

        }

        //search by age
        public static List<User> SearchByAge(int age)
        {
            return Users
                .Where(u => u.Age == age)
                .ToList();

        }

    }
}
