using Models;

namespace AcademyApp
{
    public static class MenuHelper
    {
        public static void DisplayAdminMenu(User loggedInUser)
        {
            Admin admin = loggedInUser as Admin;

            if (admin == null)
            {
                Console.WriteLine($"Error: Logged in user is not an admin.");
                return;
            }

            //Admin admin = (Admin)loggedInUser;
            //if(loggedInUser is Admin)
            //{

            //}

            Console.WriteLine($"Choose what you want to do:");
            Console.WriteLine($"1. Add new user");
            Console.WriteLine($"2. Remove user");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and 2.");
            }

            if (choice == 1)
            {
                Console.WriteLine($"You chose to add a new user.");

                Console.WriteLine($"In which role do you want to add the user?");
                var roles = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
                for (int i = 0; i < roles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {roles[i]}");
                }

                int roleChoice;
                Console.Write("Enter the number corresponding to the role: ");
                while (!int.TryParse(Console.ReadLine(), out roleChoice) || roleChoice < 1 || roleChoice > roles.Count)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {roles.Count}.");
                }

                Role selectedRole = roles[roleChoice - 1];

                Console.WriteLine("Enter the first name of the user:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the last name of the user:");
                string lastName = Console.ReadLine();
                string username = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter the username of the user:");
                    username = Console.ReadLine();

                    if (StaticDatabase.Users.Any(u => u.Username.Equals(username)))
                    {
                        Console.WriteLine("Username already exists. Please choose a different username.");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Enter the password of the user:");
                string password = Console.ReadLine();
                List<Subject> subjects = new List<Subject>();

                if (selectedRole != Role.Admin)
                {
                    //if (selectedRole == Role.Trainer)
                    //    Console.WriteLine($"On which academy the trainer will be assigned?");
                    //if (selectedRole == Role.Student)
                    //    Console.WriteLine($"On which academy the student will be assigned?");

                    Console.WriteLine($"On which academy the {selectedRole} will be assigned?");

                    var academies = Enum.GetValues(typeof(Academy)).Cast<Academy>().ToList();
                    for (int i = 0; i < academies.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {academies[i]}");
                    }

                    int academyChoice;
                    Console.Write("Enter the number corresponding to the academy: ");
                    while (!int.TryParse(Console.ReadLine(), out academyChoice) || academyChoice < 1 || academyChoice > academies.Count)
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between 1 and {academies.Count}.");
                    }

                    Academy selectedAcademy = academies[academyChoice - 1];

                    subjects = StaticDatabase.Subjects.Where(s => s.Academy == selectedAcademy).ToList();
                }

                User user = null;
                var nextId = StaticDatabase.Users.Max(u => u.Id) + 1;
                if (selectedRole == Role.Admin)
                {
                    user = new Admin(nextId, firstName, lastName, username, password);
                }
                else if (selectedRole == Role.Trainer)
                {
                    user = new Trainer(nextId, firstName, lastName, username, password, subjects);
                }
                else if (selectedRole == Role.Student)
                {
                    user = new Student(nextId, firstName, lastName, username, password, subjects);
                }

                StaticDatabase.Users.Add(user);
            }
            else if (choice == 2)
            {
                Console.WriteLine($"You chose to remove a user.");
                Console.WriteLine($"All users:");
                foreach (var user in StaticDatabase.Users)
                {
                    Console.WriteLine($"{user.Id}. {user.FullName} - {user.Role} (Username: {user.Username})");
                }

                Console.Write($"Enter the username of the user you want to remove: ");
                string usernameToRemove = Console.ReadLine();

                while (!StaticDatabase.Users.Any(u => u.Username.Equals(usernameToRemove)) || loggedInUser.Username.Equals(usernameToRemove))
                {
                    Console.WriteLine($"No user found with the username '{usernameToRemove}' or you cannot remove yourself. Please enter a valid username:");
                    usernameToRemove = Console.ReadLine();
                }

                var userToRemove = StaticDatabase.Users.First(u => u.Username.Equals(usernameToRemove));
                StaticDatabase.Users.Remove(userToRemove);
            }
        }

        public static void DisplayTrainerMenu(User loggedInUser)
        {
            Trainer trainer = loggedInUser as Trainer;

            if (trainer == null)
            {
                Console.WriteLine($"Error: Logged in user is not a trainer.");
                return;
            }

            Console.WriteLine($"Choose what you want to do:");
            Console.WriteLine($"1. List all my subjects?");
            Console.WriteLine($"2. List all students?");
            Console.WriteLine($"3. Set student grade?");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and 3.");
            }

            if (choice == 1)
            {
                Console.WriteLine($"You chose to list all your subjects.");
                Console.WriteLine($"Your subjects:");
                foreach (var subject in trainer.Subjects)
                {
                    Console.WriteLine($"{subject.Name} - {subject.Academy}");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine($"You chose to list all students.");
                Console.WriteLine($"All students:");
                var students = StaticDatabase.Users.Where(u => u.Role == Role.Student).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FullName} - {student.Username}");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine($"You chose to set a student's grade.");
                Console.WriteLine($"All students:");
                var students = StaticDatabase.Users.Where(u => u.Role == Role.Student).ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.FullName} - {student.Username}");
                }

                Console.Write($"Enter the username of the student you want to set a grade for: ");
                string username = Console.ReadLine();

                while (!students.Any(s => s.Username.Equals(username)))
                {
                    Console.WriteLine($"No student found with the username '{username}'. Please enter a valid username:");
                    username = Console.ReadLine();
                }

                var studentToGrade = students.First(s => s.Username.Equals(username)) as Student;

                Console.WriteLine("Choose a subject to set the grade for:");
                for (int i = 0; i < trainer.Subjects.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {trainer.Subjects[i].Name} - {trainer.Subjects[i].Academy}");
                }

                int subjectChoice;
                Console.Write("Enter the number corresponding to the subject: ");
                while (!int.TryParse(Console.ReadLine(), out subjectChoice) || subjectChoice < 1 || subjectChoice > trainer.Subjects.Count)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {trainer.Subjects.Count}.");
                }

                Subject selectedSubject = trainer.Subjects[subjectChoice - 1];

                Console.Write("Enter the grade (5-10): ");
                int grade;
                while (!int.TryParse(Console.ReadLine(), out grade) || grade < 5 || grade > 10)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 5 and 10.");
                }

                // Here you would set the grade for the student in the selected subject.
                studentToGrade.SetGrade(selectedSubject, grade);
            }
        }
        public static void DisplayStudentMenu(User loggedInUser)
        {
            Student student = loggedInUser as Student;

            Console.WriteLine("Here are your subjects and grades:");
            foreach (var subject in student.Subjects)
            {
                int grade = 0;

                if (student.Grades.Any(x => x.Key.Id == subject.Id))
                {
                    grade = student.Grades.First(x => x.Key.Id == subject.Id).Value;
                }

                Console.WriteLine($"{subject.Name} - {subject.Academy}: Grade: {(grade == 0 ? "Not graded yet" : grade.ToString())}");
            }
        }
    }
}
