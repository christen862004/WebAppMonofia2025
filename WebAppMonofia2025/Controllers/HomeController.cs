using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMonofia2025.Models;

namespace WebAppMonofia2025.Controllers
{
    
    //End With Controller
    //ControllerClass inherit from Controller
    public class HomeController : Controller
    {

        //MEthod inside controller calss call Actions (URL)
        //1) Method Must be Public 
        //2) Metohd Cant be Static
        //3) MEthod Cant Be OverLoad  [only in one case]
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Home/TestText ==>Endpoint
        public ContentResult TestText()
        {
            //logic........................
            //Decalre
            ContentResult result = new ContentResult();
            //fill 
            result.Content = "hello From My Controller";
            //Return
            return result;
        }
        
        //Home/testView
        public ViewResult testView()
        {
            //logic......
            //delcare
            ViewResult result = new ViewResult();
            //view name
            result.ViewName = "View1";//html +c#
            //Views/Home/View1.cshtml X
            //Views/Shared/View1.cshtml X

            //return
            return result;
        }

        //Home/TestMix?id=10&name=ahmed [Query String]
        //Home/TestMix/10?name=ahmed [Route Values only with parameter with name id]
        public IActionResult TestMix(int id,string name)
        {
            if (id % 2 == 0)
            {
                //logic
                //DRY : Dont Repeat Yorself
                return View("View1");
            }else
            {
                return Content("Hello From Action");
            }
        }

        //Home/View?ViewName=View1
        //[NonAction]
        //public ViewResult View(string ViewName)//endpoint
        //{
        //    ViewResult result = new ViewResult();
        //    result.ViewName = ViewName;
        //    return result;
        //}



        ///Action can return <summary>  Class :ActionResult==>IActionresutl
        /// 1) String      ==> ContenetResult  ==> Content
        /// 2) view        ==> ViewRsult       ==> View
        /// 3) json        ==> JsonREsult      ==> Json
        /// 4) NotFound    ==> NotFoundResult  ==> NotFound
        /// 5) unAuthorize ==> UnsuthoroizeResult
        /// 6) void        ==> EmptyResult
        /// ......
        /// </summary>
        /// <returns></returns>
        

        




 

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
