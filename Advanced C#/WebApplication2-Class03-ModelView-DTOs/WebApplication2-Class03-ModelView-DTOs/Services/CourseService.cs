

using WebApplication2_Class03_ModelView_DTOs.Models.Database;
using WebApplication2_Class03_ModelView_DTOs.Models.ViewModels;

namespace WebApplication2_Class03_ModelView_DTOs.Services
{
    //retreiving the courses from the db
    public class CourseService
    {
        public List<CourseViewModel> GetCoursesWithMoreThanNineClasses()
        {
            //get the data from the staticDb
            var courses = StaticDb.Courses.Where(x => x.NumberOfClasses > 0).ToList();//we add .ToList() cuz it retreives Ienuumerable and we need to be a string

            //we don't want to send the domiain model, we want to send the viewModelVourses
            List<CourseViewModel> result = new List<CourseViewModel>();

            foreach (var course in courses)
            {
                result.Add(new CourseViewModel
                {
                    Name = course.Name,
                    NumberOfClasses = course.NumberOfClasses,
                }); //we map the domain model into the view model and return the result
            }

            return result;
        }

    }
}
