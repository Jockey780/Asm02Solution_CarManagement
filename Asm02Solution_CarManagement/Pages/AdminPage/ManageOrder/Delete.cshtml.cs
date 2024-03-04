using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrder
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService orderService;

        public DeleteModel()
        {
            orderService = new OrderService();
        }

        [BindProperty]
      public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }
            }

            var order = orderService.GetOrderByID((int)id);

            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = orderService.DeleteOrder((int)id);
            return RedirectToPage("./Index");
        }
    }
}
