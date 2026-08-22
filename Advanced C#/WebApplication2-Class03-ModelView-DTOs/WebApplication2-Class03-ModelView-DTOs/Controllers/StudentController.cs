using Microsoft.AspNetCore.Mvc;
using WebApplication2_Class03_ModelView_DTOs.Models.Database;
using WebApplication2_Class03_ModelView_DTOs.Services;

namespace WebApplication2_Class03_ModelView_DTOs.Controllers
{
    //to acces the actions here we use ControllerName/ActionName
    public class StudentController : Controller
    {
        private StudentService _studentService;


        //BAD PRACTICE avoid accessing the db and using the domain models in the controller
        public IActionResult GetAllStudents()
        {
            return Json(StaticDb.Students);
        }

        public StudentController()
        {
            _studentService = new StudentService();
        }
        public IActionResult GetAllStudentById(int Id)
        {
            var studentDto = _studentService.GetStudentById(Id); //here the service returns dto not a model
            if (studentDto != null) {
                return Json(studentDto);
            }

            return Content("Student not found.");
        }
    }
}
