using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrder
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService orderService;

        public IndexModel()
        {
            orderService = new OrderService();
        }

        public IList<Order> Order { get; set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                Order = orderService.GetOrdersList();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
