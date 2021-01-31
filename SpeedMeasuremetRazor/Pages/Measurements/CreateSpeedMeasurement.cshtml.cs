using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class CreateSpeedMeasurementModel : PageModel
    {
        private ILocationRepo _locationRepo;
        private Random random = new Random();
        public ILocationRepo LocationRepo
        {
            get { return _locationRepo;}
        }
        private ISpeedMeasurementRepo _speedMeasurementRepo;

        
        public SpeedMeasurement SpeedMeasurement { get; set; }

        [BindProperty]
        public int LocationId { get; set; }

        public string InfoText { get; set; }
        public CreateSpeedMeasurementModel(ILocationRepo locationRepo, ISpeedMeasurementRepo speedMeasurementRepo)
        {
            _locationRepo = locationRepo;
            _speedMeasurementRepo = speedMeasurementRepo;
        }
       
        public List<SelectListItem> Options { get; set; }
        public void OnGet()
        {
            InfoText = "Look in the viewfinder and press the button";
            CreateOtionsList();
        }

        public void CreateOtionsList()
        {
            Options = LocationRepo.GetAllLocations().Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Address
                }).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            
            int randomSpeed = random.Next(-20, 375);
            Location location = LocationRepo.GetLocation(LocationId);
            try
            {
                _speedMeasurementRepo.AddSpeedMeasurement(randomSpeed, location, MockData.RandomImage);
            }
            catch (CalibreringsException cex)
            {
                CreateOtionsList();
                InfoText = $"The camera must be calibrated contact the support department or try again! {cex.Message}";
                return Page();
            }
            catch (ArgumentException aex)
            {
                CreateOtionsList();
                InfoText = $"The camera must be calibrated contact the support department or try again! {aex.Message}";
                return Page();
            }
            catch ( Exception ex)
            {
                InfoText = $"Something went wrong!Contact the support department {ex.Message}";
                CreateOtionsList();
                return Page();
            }
            return RedirectToPage("Index");
        }

        
    }
}
