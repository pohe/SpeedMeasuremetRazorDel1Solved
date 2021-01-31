using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        public ILocationRepo locationrepo { get; set; }

        public IndexModel(ILocationRepo repositoryLocation)
        {
            locationrepo = repositoryLocation;
        }
        public void OnGet()
        {
        }

        

        
    }
}
