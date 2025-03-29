using Microsoft.AspNetCore.Mvc;
using WebAppMonofia2025.Models;

namespace WebAppMonofia2025.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL=new StudentBL();
        public IActionResult All()
        {
            //get data from model
            List<Student> StudentList= studentBL.GetAll();

            //send view
            return View("ShowAll",StudentList);//View With Employee List
            //ViewNAme ShowAll (Views/Stduent | Views/Share)
            //Model Type List<student>
        }

        public IActionResult DEtails(int id)
        {
            Student std = studentBL.GetByID(id);
            return View("DEtails",std);//Model with type Student
        }
    }
}
