using Microsoft.AspNetCore.Mvc;
using WebApplication2_Class03_ModelView_DTOs.Models.ViewModels;
using WebApplication2_Class03_ModelView_DTOs.Services;

namespace WebApplication2_Class03_ModelView_DTOs.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {

        private CourseService _courseService; //we need an instance of the service so we can call it

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("getCourses")]
        public IActionResult GetCourses()
        {
            List<CourseViewModel> courses = _courseService.GetCoursesWithMoreThanNineClasses();
            if (courses != null && courses.Any())
            {
                return View(courses);
            }
            return Content("No courses uvailable.");

        }

    }
}
