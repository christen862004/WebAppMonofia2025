using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;


namespace WebAppMonofia2025.Controllers
{
    public class EmployeeController : Controller
    {
        //DIP  + OCP + ISP + SRP (IOC)
        IEmployeeRepository EmployeeRepository;
        IDepartmentRepository DepartmentRepository;

        public EmployeeController
            (IEmployeeRepository EmpREpo,IDepartmentRepository deptRepo)//inject
        {
            EmployeeRepository = EmpREpo; //new EmployeeRepository();//dont craete
            DepartmentRepository = deptRepo;//new DepartmentRepository();
        }

        public IActionResult Index()
        {
            List<Employee> EmpList = EmployeeRepository.GetAll(); 
            return View("Index",EmpList);//View Index,Model EmloyeeList
        }

        public IActionResult CheckOdd(int Salary,string Address)
        {
            if (Salary % 2 == 0)
                return Json(false);
            return Json(true);
        }

        #region EndpointREturn Partial View

        public IActionResult GetEmpCard(int id)
        {
            Employee emp = EmployeeRepository.GetByID(id);
            return PartialView("_EmpCardPartial", emp);
        }
        #endregion

        #region     Test Ajax 

        public IActionResult ShowDepts()
        {
            List<Department> depList = DepartmentRepository.GetAll();
            return View("ShowDepts", depList);
        }
        //get deptid ==>list <Employee>
        //Employee/GetEmpsByDEptID?deptID=1
        public IActionResult GetEmpsByDEptID(int deptID)
        {
            List<Employee> empList = EmployeeRepository.GetByDeptId(deptID);
            return Json(empList);
        }

        #endregion
        #region New

        public IActionResult New()
        {
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New");
        }

        //cant handel any forign request
        [HttpPost]
        [ValidateAntiForgeryToken]//login __RequestVerificationToken [html helper | tag helper]
        public IActionResult SaveNew(Employee empFromReq)
        {
            if (ModelState.IsValid==true)//dont use if manual | using validation attribute Model
            {
                try
                {
                    EmployeeRepository.Add(empFromReq);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch (Exception ex)
                {
                    //send problem to view Validation Action Scope
                    //ModelState.AddModelError("DepartmentID", "Please Select Department");
                    ModelState.AddModelError("other", ex.InnerException.Message);

                }
            }
            //refill ViewDat List
            ViewData["DeptList"] = DepartmentRepository.GetAll();
            return View("New", empFromReq);
        }
        #endregion

        #region DEtails
        //href="/Employee/Details/1?name=Ahmed"
        public IActionResult DEtails(int id,string name)
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
            Employee empModel=EmployeeRepository.GetByID(id);
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
            Employee empModel =EmployeeRepository.GetByID(id);

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

        #region Edit
        public IActionResult Edit(int id)
        {
            Employee empModel = EmployeeRepository.GetByID(id);
            //Create ViewModel
            EmployeeWithDeptListViewModel empVM = new EmployeeWithDeptListViewModel();
            //mapping
            empVM.Id= empModel.Id;
            empVM.Name= empModel.Name;
            empVM.ImageUrl= empModel.ImageUrl;
            empVM.Address= empModel.Address;
            empVM.Salary= empModel.Salary;
            empVM.DepartmentID = empModel.DepartmentID;

            empVM.DeptList = DepartmentRepository.GetAll();
            
            //send vm to view
            return View("Edit",empVM);//
        }


        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel empFromRequest)//Employee empFromRequest,int id)
        {
            if (empFromRequest.Name != null && empFromRequest.Salary>6000)
            {
                //get old refernece 
                Employee empModel = 
                   EmployeeRepository.GetByID(empFromRequest.Id);

                //mapp
                empModel.Name=empFromRequest.Name;
                empModel.Address=empFromRequest.Address;
                empModel.Salary=empFromRequest.Salary;//<--
                empModel.ImageUrl=empFromRequest.ImageUrl;//<--
                empModel.DepartmentID=empFromRequest.DepartmentID;

                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }

            empFromRequest.DeptList=DepartmentRepository.GetAll(); //refill 
            return View("Edit", empFromRequest);
        }
        #endregion

        #region DElete
        public IActionResult Delete(int id)
        {
            Employee empModel = EmployeeRepository.GetByID(id);
            return View("Delete", empModel);
        }
        #endregion
    }
}
