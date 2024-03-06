﻿using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Service;

namespace Asm02Solution_CarManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService userService;
        public LoginModel(IUserService userService)
        {
            this.userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public IActionResult OnPostLogin()
        {
            var email = Request.Form["email"];
            var password = Request.Form["password"];

            var user = userService.GetUserByEmailAndPassword(email, password);

            if (user == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }

            var userJson = JsonConvert.SerializeObject(user);

            HttpContext.Session.SetString("User", userJson);

            if (user.Role == "Admin")
            {
                // Đăng nhập thành công cho Admin, 
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToPage("/AdminPage/Dashboard");
            }
            else if (user.Role == "Customer")
            {
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToPage("/CustomerPage/UserProfile");
            }
            else
            {
                // Đăng nhập thất bại, hiển thị thông báo.
                ViewData["notification"] = "Invalid email or password.";
                return Page();
            }
        }
    }
}
