using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service;
using Microsoft.EntityFrameworkCore;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrder
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;

        public CreateModel()
        {
            orderService = new OrderService();
            userService = new UserService();
        }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("Role") == "Admin")
            {
                var UserTypeList = userService.GetUserTypeList();
                var userSelectList = UserTypeList.Select(id => new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                }).ToList();

                ViewData["UserId"] = new SelectList(userSelectList, "Value", "Text");
                return Page();
            }
            return RedirectToPage("/Login");
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Order = orderService.CreateOrders(Order);
            return RedirectToPage("./Index");
        }
    }
}
