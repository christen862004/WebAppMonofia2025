using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    public class StateController : Controller
    {
       //Store In server Session

        public IActionResult SetSession()
        {
            //logic .....
            //Store State using Session server
            //store object ==> json ==>string slide
            HttpContext.Session.SetString("Name", "Ahmedd");
            HttpContext.Session.SetInt32("Age",22);//write session
            //logic
            return Content("Session Success");
        }

        public IActionResult GetSession()
        {
            //logic
            string n= HttpContext.Session.GetString("Name");
            int? a= HttpContext.Session.GetInt32("Age");
            return Content($"Session Get Success {n} \t {a}");
        }

        public IActionResult SetCookie()
        {
            //logic  write cookie send Client Broswer "'Response object" Session Expired
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", "Mohamed");
            //Presistent Cookie "Expiration Date"
            CookieOptions cookieOptions = new CookieOptions() { 
                Expires = DateTime.Now.AddDays(1)
            };
            HttpContext.Response.Cookies.Append("Age", "22",cookieOptions);
            
            return Content("Cookie Save Success");
        }

        public IActionResult GetCookie()
        {
            //Server read cookie from client request
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"Cookie Read {n}\t{a}");
        }
    }
}
