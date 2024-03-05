using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;
using System.Net;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderDetailService orderDetailService;

        public DeleteModel()
        {
            orderDetailService = new OrderDetailService();
        }

        [BindProperty]
      public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var orderdetail = orderDetailService.GetOrderDetailByID((int)id);

                if (orderdetail == null)
                {
                    return NotFound();
                }
                else
                {
                    OrderDetail = orderdetail;
                }
                return Page();
            }
            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderdetail = orderDetailService.DeleteOrderDetail((int)id);
            return RedirectToPage("./Index");
        }
    }
}
