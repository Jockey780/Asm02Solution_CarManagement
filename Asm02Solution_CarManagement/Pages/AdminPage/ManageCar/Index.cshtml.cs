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
    public class IndexModel : PageModel
    {
        private readonly ICarService carService;

        public IndexModel()
        {
            carService = new CarService();
        }

        public IList<Car> Car { get;set; } = default!;

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                Car = carService.GetCarsList();
                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
