using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public ISpeedMeasurementRepo repo { get; set; }

        public IndexModel(ISpeedMeasurementRepo repositoryMeasurementRepo)
        {
            repo = repositoryMeasurementRepo;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostDelete(int id)
        {
            repo.DeleteSpeedMeasurement(id);
            return Page();
        }
    }
}
