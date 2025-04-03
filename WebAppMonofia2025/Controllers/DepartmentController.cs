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
        #region New
        public IActionResult New()
        {
            return View("New");//Model null
        }
        //Refill Form | test Post method
        ///Department/SaveNew?Name=sd&ManagerName=Ahmed <summary>
        /// Department/SaveNew?Name=sd
        
        [HttpPost]//Handel only post request
        public IActionResult SaveNew(Department deptFromRequest)//string Name,string ManagerName)
        {
            //if (Request.Method == "Post")
            //{
            if (deptFromRequest.Name != null)
            {
                //save 
                context.Department.Add(deptFromRequest);
                context.SaveChanges();//save in db
                                        //DRY
                return RedirectToAction("Index", "Department");
            }
            //return New View
            return View("New", deptFromRequest);//invalid model Department
            //}
        }

        // Get Department/method1
        [HttpGet]
        public IActionResult method1()//valid
        {
            return Content("Method1");
        }

        //Post Department/method1
        [HttpPost]
        public IActionResult method1(string name)//valid using model binding name=null
        {
            return Content("Method1 Copy");
        }
        #endregion
    }
}
