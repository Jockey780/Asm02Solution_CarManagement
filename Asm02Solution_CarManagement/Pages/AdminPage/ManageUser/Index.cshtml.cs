using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageUser
{
    public class IndexModel : PageModel
    {
        private readonly IUserService userService;

        public IndexModel()
        {
            userService = new UserService();
        }

        public IList<User> User { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                User = userService.GetUsersList().Where(a => a.Role == "Customer").ToList();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
