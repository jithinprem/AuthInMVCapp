using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWithAuth.Models;
using System.Net;
using System.Security.Claims;

namespace StudentCourseWithAuth.Controllers
{
    public class LoginController : Controller
    {
        //public VMLogin Credential { get; set; }
        public LoginController() { }

        public IActionResult LogInAction() {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Menu/Index");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return Redirect("/Home/Index"); // Redirect to a desired page after logout
        }


        public IActionResult InvalidLogin() {
            return View();
        }

        public IActionResult NotAuthorized() { return View(); }

        [HttpPost]
        public async Task<IActionResult> LogIn(VMLogin Credential)
        {

            if (!ModelState.IsValid) return View();

            // Verify the credential
            if (Credential.UserName == "admin" && Credential.Password == "password")
            {
                // Creating the security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", "true"),
                    new Claim("Manager", "true"),
                    new Claim("EmploymentDate", "2021-02-01"),
                    new Claim("Power", "10")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe
                };
                //await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);

                return Redirect("/Menu/Index");
            }
            else if (Credential.UserName == "teacher" && Credential.Password == "password") {

                // creating a new security context for teacher
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "teacher"),
                    new Claim(ClaimTypes.Email, "teacher@mywebsite.com"),
                    new Claim("Department", "Teacher"),
                    //new Claim("Admin", "false"),
                    new Claim("Manager", "false"),
                    new Claim("EmploymentDate", "2023-08-01"),
                    new Claim("Power", "6")

                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe
                };
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal, authProperties);

                return Redirect("/Menu/Index");

            }

            
            return Redirect("/Login/InvalidLogin");
        }
    }
}
