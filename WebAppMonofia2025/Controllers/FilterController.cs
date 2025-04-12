using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppMonofia2025.Filtters;

namespace WebAppMonofia2025.Controllers
{
   //[HandelError]
    public class FilterController : Controller
    {
      //  [Authorize]
        public IActionResult testUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Claim idClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id= idClaim.Value;

                Claim addressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");
                //string id = idClaim.Value;
                return Content("Welcome "+User.Identity.Name);
            }
            //disply user data from Cookie
            return Content("Welcome Guset");
        }




        [HandelError]
        [AllowAnonymous]
        public IActionResult M1()
        {
            throw new Exception("Exception 1");
            return View();
        }
        //[HandelError]
        public IActionResult M2()
        {
            throw new Exception("Exception 1");
            return View();
        }
    }
}
