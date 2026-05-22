namespace Models
{
    public class Admin : User
    {
        public Admin(int id, string firstName, string lastName, string username, string password)
            : base(id, firstName, lastName, username, password, Role.Admin)
        {
        }
    }
}
