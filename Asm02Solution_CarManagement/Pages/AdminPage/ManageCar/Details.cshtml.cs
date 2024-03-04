using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageCar
{
    public class DetailsModel : PageModel
    {
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;

        public DetailsModel()
        {
            carService = new CarService();
            categoryService = new CategoryService();
        }

        public Car Car { get; set; } = default!;
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                Car car = carService.GetCarByID((int)id);
                if (car == null)
                {
                    return NotFound();
                }
                else
                {
                    Car = car;
                    Category = categoryService.GetCategoryById(Car.CategoryId);
                }
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
