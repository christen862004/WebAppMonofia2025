using Microsoft.AspNetCore.Mvc;
using WebAppMonofia2025.Models;

namespace WebAppMonofia2025.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public DepartmentController()
        {
            
        }
        public IActionResult Index()
        {
            List<Department> DepTList= context.Department.ToList();
            return View("Index",DepTList); //view with name Index ,Model =List<department>
            //1 return View("Index"); //view with name Index ,Model =null   X
            //3 return View();//View With the same action name ,Model =null  X
            //4 return View(DepTList); //View With the same action anme "Index" ,Model =DeptList
        }
    }
}
