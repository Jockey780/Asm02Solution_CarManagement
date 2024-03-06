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

        public IList<Car> Car { get; set; } = new List<Car>();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //public IActionResult OnGetAsync()
        //{
        //    if (HttpContext.Session.GetString("Role") == "Admin")
        //    {
        //        Car = carService.GetCarsList();
        //        return Page();
        //    }
        //    return RedirectToPage("/Login");
        //}

        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                // Get the list of cars
                var cars = carService.GetCarsList();

                // Filter the cars based on the search value
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    cars = cars.Where(c => c.CarName.Contains(SearchTerm) || c.CategoryId.ToString() == SearchTerm).ToList();
                }

                Car = cars.Count > 0 ? cars : Car;

                return Page();
            }
            return RedirectToPage("/Login");
        }
    }
}
