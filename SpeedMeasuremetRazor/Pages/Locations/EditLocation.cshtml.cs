using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class EditLocationModel : PageModel
    {
        private ILocationRepo repo;

        [BindProperty]
        public Location Location { get; set; }

        public EditLocationModel(ILocationRepo repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Location = repo.GetLocation(id);
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateLocation(Location);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete(int id)
        {
            repo.DeleteLocation(id);
            return RedirectToPage("Index");
        }
    }
}
