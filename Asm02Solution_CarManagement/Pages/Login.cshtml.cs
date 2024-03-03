using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            if (user.Role == "Admin")
            {
                // Đăng nhập thành công cho Admin, 
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToPage("/AdminPage/Dashboard");
            }
            else if (user.Role == "Customer")
            {
                // Đăng nhập thành công cho Customer, .
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToPage("/CustomerPage/ListProfile");
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
