﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Service;
using System.Security.Principal;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageCar
{
    public class CreateModel : PageModel
    {
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;

        public CreateModel()
        {
            carService = new CarService();
            categoryService = new CategoryService();
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {

                var _categories = categoryService.GetCatagories();

                var categories = _categories.Select(id => new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                }).ToList();

                ViewData["CategoryId"] = new SelectList(categories, "Value", "Text");
                return Page();
            }
            return RedirectToPage("/Login");
        }

        [BindProperty]
        public Car Car { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {          
            Car result = carService.CreateCars(Car);
            if (result != null)
            {
                ViewData["notification"] = "Email is existed";
                return OnGet();
            }
            return RedirectToPage("./Index");
        }
    }
}
