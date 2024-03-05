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

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageOrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly IOrderDetailService orderDetailService;
        private readonly ICarService carService;

        public CreateModel()
        {
            orderDetailService = new OrderDetailService();
            carService = new CarService();
        }

        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("Role") == "Admin")
            {
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

                ViewData["CarId"] = new SelectList(carSelectList, "Value", "Text");
                ViewData["OrderId"] = new SelectList(orderSelectList, "Value", "Text");
                return Page();
            }
            return RedirectToPage("/Login");
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          OrderDetail = orderDetailService.CreateOrderDetail(OrderDetail);
            if(OrderDetail == null)
            {
                ViewData["notification"] = "The order detail ID is existed";
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
