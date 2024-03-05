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
using System.Net;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class EditModel : PageModel
    {
        private readonly IOrderDetailService orderDetailService;
        private readonly ICarService carService;

        public EditModel()
        {
            orderDetailService = new OrderDetailService();
            carService = new CarService();
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

                var CarTypeList = carService.GetCarType();
                var OrderTypeList = orderDetailService.GetOrderDetailType();

                var carSelectList = CarTypeList.Select(id => new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                }).ToList();
                var orderSelectList = OrderTypeList.Select(id => new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                }).ToList();

                OrderDetail = orderdetail;
                ViewData["CarId"] = new SelectList(carSelectList, "Value", "Text");
                ViewData["OrderId"] = new SelectList(orderSelectList, "Value", "Text");
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
                OrderDetail = orderDetailService.UpdateOrderDetail(OrderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.OrderId))
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

        private bool OrderDetailExists(int id)
        {
          return orderDetailService.GetOrderDetailByID((int)id) != null;
        }
    }
}
