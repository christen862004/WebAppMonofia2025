using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMonofia2025.Controllers
{
    [Authorize(Roles ="Admin")]//cookie ==> Role =Admin
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult New()
        {
            //User.IsInRole("Admin");
            
            return View("New");
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = roleViewModel.RoleName
                };
                IdentityResult result=await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("New", roleViewModel);
        }
    }
}
