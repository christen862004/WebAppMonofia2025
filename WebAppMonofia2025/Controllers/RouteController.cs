using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    //[Route("r1")]
    public class RouteController : Controller
    {
        //Route/Method1[defult Route]
        //r1 (custom Route)
        //r1?id=10&name=ahmed
        //r1/40/ahmed   [3 segnamet]
        //r1/20/Mohamed
        //r1/20
        //[Route("/M1")]//m1
        //r1/MEthod1
        public IActionResult Method1(int age,string name,string color)
        {

            return Content("method1");
        }
      
        
        //Route/Method2
        //r2
        //r1/method
        public IActionResult Method2()
        {
            return Content("method2");
        }

        //[Route("r3/{id:int}/{name?}",Name ="route3")]
        [Route("r3")]
        public IActionResult Method3()
        {
            return Content("Method3");
        }
    }
}
