using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;
using Newtonsoft.Json;

namespace Asm02Solution_CarManagement.Pages.CustomerPage
{
    public class UserProfileModel : PageModel
    {
        private readonly IUserService userService;

        public UserProfileModel()
        {
            userService = new UserService();
        }

        public IList<User> User { get; set; } = default!;

        public IActionResult OnGetAsync()
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == "Customer")
            {
                var loggedInAccountJson = HttpContext.Session.GetString("User");
                var loggedInAccount = JsonConvert.DeserializeObject<User>(loggedInAccountJson);

                if (loggedInAccount != null)
                {
                    User = new List<User> { loggedInAccount };
                    return Page();
                }
            }

            return RedirectToPage("/Login");
        }
    }
}

