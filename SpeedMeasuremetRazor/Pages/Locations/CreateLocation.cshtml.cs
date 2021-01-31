using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class CreateLocationModel : PageModel
    {
        private ILocationRepo repo;

        [BindProperty]
        public Location Location { get; set; }

        public string InfoText { get; set; }
        public CreateLocationModel(ILocationRepo repository)
        {
            repo = repository;
        }
        public IActionResult OnGet()
        {
            InfoText = "Enter a new location!";
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                repo.AddLocation(Location);
            }
            catch (UniqIdException uex)
            {
                InfoText = $"Something went wrong! {uex.Message}";
                return Page();
            }
            return RedirectToPage("Index");
        }

    }
}
