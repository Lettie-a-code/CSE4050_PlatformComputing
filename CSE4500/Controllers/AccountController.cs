using CSE4050_SignIn.Data;
using CSE4050_SignIn.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Buffers.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Claims;

// Class is responsible for directing user to appropriate view based on credentials
public class AccountController : Controller{
    
    [HttpGet]
    // Displays the login page (GET request)
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
        //Handles POST request for login, receives user input, and processes authentication
        // Handles the login form submission, authenticates the user, and redirects based on role   
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        // Validates the input model; if invalid, redisplay the login form with validation errors   
        if (!ModelState.IsValid) return View(vm);

        string role = null;

        if (vm.Email == "admin@dogcare.com" && vm.Password == "Admin123")
        {
            role = "Admin";
        }
        else if (vm.Email == "tech@dogcare.com" && vm.Password == "Tech123")
        {
            role = "Technician";
        }

        if (role != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, vm.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            // ✅ UPDATED PART
            if (role == "Admin")
            {
                return RedirectToAction("AdminPage", "Account");
            }
            else if (role == "Technician")
            {
                return RedirectToAction("EmployeePage", "Account");
            }
        }

        ModelState.AddModelError("", "Invalid email or password.");
        return View(vm);
    }

    // Administration credentials are directed to Admin. navigation page
    public IActionResult AdminPage()
    {
        return View();
    }
    // Technician credentials are directed to Tech. navigation page
    public IActionResult EmployeePage()
    {
        return View();
    }
}
