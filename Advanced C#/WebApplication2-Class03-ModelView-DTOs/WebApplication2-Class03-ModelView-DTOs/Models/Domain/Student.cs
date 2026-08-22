namespace WebApplication2_Class03_ModelView_DTOs.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Course Course { get; set; } //whole Course obj here so with one call and one join to be retreived information directlly not go 2 times to th db, one call to db by retreiving the whole Course object
    }
}
