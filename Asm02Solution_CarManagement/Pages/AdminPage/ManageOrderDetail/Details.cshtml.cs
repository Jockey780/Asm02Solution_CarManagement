using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.CarManagementContext _context;

        public DetailsModel(BusinessObjects.Models.CarManagementContext context)
        {
            _context = context;
        }

      public OrderDetail OrderDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(m => m.OrderId == id);
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
    }
}
