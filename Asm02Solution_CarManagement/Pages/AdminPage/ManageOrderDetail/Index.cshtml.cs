using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailService orderDetailService;

        public IndexModel()
        {
            orderDetailService = new OrderDetailService();
        }

        public IList<OrderDetail> OrderDetail { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                OrderDetail = orderDetailService.GetOrderDetailList();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
