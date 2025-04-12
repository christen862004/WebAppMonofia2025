using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppMonofia2025.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> UserManager,SignInManager<ApplicationUser> signInManager)
        {
            userManager = UserManager;
            this.signInManager = signInManager;
        }

        #region Register

        
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser userFromDb= new ApplicationUser() { 
                    UserName=userViewModel.UserName, 
                    Email=userViewModel.Email,
                    PasswordHash=userViewModel.Password
                };
                //add db
                IdentityResult result=await  userManager.CreateAsync(userFromDb,userViewModel.Password);
                if (result.Succeeded) {
                    //add info in userClaim Table
                    //await userManager.AddClaimAsync(userFromDb, new Claim("", ""));
                    await userManager.AddToRoleAsync(userFromDb, "Admin");
                    await signInManager.SignInAsync(userFromDb, false);//----------
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", userViewModel);
        }

        #endregion

        #region Signout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//<----------------
        public async Task<IActionResult> Login(LoginViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                //check account 
                ApplicationUser userFromDB=await  userManager.FindByNameAsync(userViewModel.UserName);
                if(userFromDB != null)
                {
                    bool found=await userManager.CheckPasswordAsync(userFromDB, userViewModel.Password);
                    if (found)
                    {
                        //create cookie
                        //ID ,Username ,Email ,Role ,Address
                        await signInManager.SignInAsync(userFromDB, userViewModel.RememeberMe);
                        //List<Claim> claims = new List<Claim>();
                       // claims.Add(new Claim("Address", userFromDB.Address));
                        //await signInManager.SignInWithClaimsAsync(userFromDB, userViewModel.RememeberMe, claims);
                        return RedirectToAction("Index", "Employee");
                    }

                }
                ModelState.AddModelError("", "UserName or Password invalid");
            }
            return View("Login",userViewModel);
        }
        #endregion

    }
}
