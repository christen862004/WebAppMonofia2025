using Microsoft.AspNetCore.Mvc;


namespace WebAppMonofia2025.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context;
        int counter = 0;
        public EmployeeController()
        {
            context = new ITIContext();
        }


        public string incr()//1 2 3 4 || 1 1 1 1 1 1
        {
            counter++;
            return counter.ToString();
        }

        public IActionResult Index()
        {
            List<Employee> EmpList= context.Employee.ToList();//pagaination
            return View("Index",EmpList);//View Index,Model EmloyeeList
        }

        #region DEtails
        public IActionResult DEtails(int id)
        {
            //From Datasource
            string Msg = "Hello";
            List<string> brches=new List<string>() 
            { "Assiut" ,"Alex","Monofia" ,"Banha" , "Cairo"};
            int temp = 20;
            string Color = "red";
            //Per Request ,From one Action to return View
            ViewData["Message"] = Msg;
            ViewData["brch"]    = brches;
            ViewData["temp"]    = temp;
            ViewBag.xyz = 12;//ViewData["xyz"]=12
            ViewData["clr"] = "red";
            ViewBag.clr = "blue";
            //new key ,override  1,throw exception 1
            //---------------------------------------------------------
            Employee empModel= context.Employee.FirstOrDefault(e => e.Id == id);
            return View("DEtails", empModel);//View DEtails,Model Employee
        }

        public IActionResult DetailsVM(int id)
        {
            //Collect data from different data source
            string Msg = "Hello";
            List<string> brches = new List<string>()
            { "Assiut" ,"Alex","Monofia" ,"Banha" , "Cairo"};
            int temp = 20;
            string Color = "red";
            Employee empModel = context.Employee.FirstOrDefault(e => e.Id == id);

            //declare ViewModel
            EmployeeWithBracnchListColorMsgViewModel EmpVM =new();
            //Map Data FRom Source To Destination (VM Object)

            EmpVM.Color = "red";
            EmpVM.Branches= brches;
            EmpVM.Temp = 30;
            EmpVM.Message = Msg;
            EmpVM.EmpID = empModel.Id;
            EmpVM.EmpName = empModel.Name;

            //send ViewModle To View Diaplay
            return View("DetailsVM",EmpVM);//View DetailsVM ,Model EmployeeWithBracnchListColorMsgViewModel
        }
        #endregion
    }
}
