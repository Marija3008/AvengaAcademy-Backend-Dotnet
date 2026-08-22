using WebApplication2_Class03_ModelView_DTOs.Models.Database;
using WebApplication2_Class03_ModelView_DTOs.Models.Domain;
using WebApplication2_Class03_ModelView_DTOs.Models.DTOs;

namespace WebApplication2_Class03_ModelView_DTOs.Services
{
    public class StudentService
    {
        public StudentWithCourseDto GetStudentById(int id)
        {
            Student student = StaticDb.Students.FirstOrDefault(x => x.Id == id);

            if(student == null)
            {
                return null;
            }

            StudentWithCourseDto studentDto = new StudentWithCourseDto
            {
                Id = student.Id,
                Fullname = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                NameOfActiveCourse = student.Course.Name
            };

            return studentDto;
        }
    }
}
