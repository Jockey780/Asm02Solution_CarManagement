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
        private readonly IUserService userService;

        public IndexModel()
        {
            orderService = new OrderService();
            userService = new UserService();
        }

        public IList<Order> Order { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                // Get the list of categories
                var orders = orderService.GetOrdersList();

                // Filter the categories based on the search value
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    orders = orders.Where(o => o.OrderStatus.Contains(SearchTerm)).ToList();
                }

                Order = orders.Count > 0 ? orders : Order;

                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
