﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Service;
using Humanizer.Localisation;

namespace Asm02Solution_CarManagement.Pages.AdminPage.ManageCategory
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService categoryService;

        public IndexModel()
        {
            categoryService = new CategoryService();
        }

        public IList<Category> Category { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                Category = categoryService.GetAllCategory();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}