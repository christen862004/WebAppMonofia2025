using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // ITIContext context = new ITIContext();
        IDepartmentRepository DepartmentRepository;

        public DepartmentController(IDepartmentRepository deptReop)
        {
            DepartmentRepository = deptReop;// new DepartmentRepository();
        }

        public IActionResult Index()
        {
            List<Department> DepTList= DepartmentRepository.GetAll();
            return View("Index",DepTList);
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
                DepartmentRepository.Add(deptFromRequest);
                DepartmentRepository.Save();
                return RedirectToAction("Index", "Department");
            }
            //return New View
            return View("New", deptFromRequest);//invalid model Department
            //}
        }

        // Get Department/method1
        [HttpGet]
        [AllowAnonymous]
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
