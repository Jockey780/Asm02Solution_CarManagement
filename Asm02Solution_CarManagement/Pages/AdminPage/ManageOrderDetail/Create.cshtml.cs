using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.CarManagementContext _context;

        public CreateModel(BusinessObjects.Models.CarManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarName");
        ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OrderDetails == null || OrderDetail == null)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
