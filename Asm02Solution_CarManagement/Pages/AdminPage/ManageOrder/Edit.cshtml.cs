using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrder
{
    public class EditModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;

        public EditModel()
        {
            orderService = new OrderService();
            userService = new UserService();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {

                var UserTypeList = userService.GetUserTypeList();

                var userSelectList = UserTypeList.Select(id => new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                }).ToList();
                if (id == null)
                {
                    return NotFound();
                }

                var order = orderService.GetOrderByID((int)id);

                if (order == null)
                {
                    return NotFound();
                }
                Order = order;
                ViewData["UserId"] = new SelectList(userSelectList, "Value", "Text");
                return Page();
            }
            return RedirectToPage("/Login");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Order = orderService.UpdateOrder(Order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
          return orderService.GetOrderByID((int)id) != null;
        }
    }
}
