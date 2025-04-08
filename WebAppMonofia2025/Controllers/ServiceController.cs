using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServiceController(IDepartmentRepository deptRepo)//inject Contstrict
        {
            this.deptRepo = deptRepo;
        }
        //Model Binder
        //Interface Service Provider (IOC Container)
        public IActionResult Index()//Employee emp,[FromServices]IDepartmentRepository deptREpos2)//inject Method
        {
            ViewData["ID"] = deptRepo.ID;
            return View("Index");
        }
    }
}
