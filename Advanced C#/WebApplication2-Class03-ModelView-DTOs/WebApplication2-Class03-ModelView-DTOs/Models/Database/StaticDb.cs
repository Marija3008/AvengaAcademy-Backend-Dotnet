using WebApplication2_Class03_ModelView_DTOs.Models.Domain;

namespace WebApplication2_Class03_ModelView_DTOs.Models.Database
{
    public static class StaticDb
    {
        static StaticDb()
        {//constructor where we emideatelly call the private methods for retreiving the student and course lists
            LoadCourses();
            LoadStudents();
        } 

        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }


        //static methods for retreiving data
        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new Course() {Id = 1, Name = "C# Basic", NumberOfClasses = 10},
                new Course() {Id = 2, Name = "C# Advanced", NumberOfClasses = 15},
                new Course() {Id = 3, Name = "SQL", NumberOfClasses = 7},
                new Course() {Id = 4, Name = "Java Script Advanced", NumberOfClasses = 12},
                new Course() {Id = 5, Name = "Java Script Basic", NumberOfClasses = 10},
                new Course() {Id = 6, Name = "MVC", NumberOfClasses = 10},
                new Course() {Id = 7, Name = "API", NumberOfClasses = 15},
            };
        }


        private static void LoadStudents()
        {
            Students = new List<Student>()
            {
                new Student() {
                    Id = 1,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[0]
                },
                new Student() {
                    Id = 2,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[1]
                },
                new Student() {
                    Id = 3,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[2]
                },
                new Student() {
                    Id = 4,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[3]
                },
                new Student() {
                    Id = 5,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[4]
                },
                new Student() {
                    Id = 6,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[5]
                },
                new Student() {
                    Id = 7,
                    FirstName = "Aleksandar",
                    LastName = "Aleksov",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    Course = Courses[6]
                },
            };
        }
    }
}
