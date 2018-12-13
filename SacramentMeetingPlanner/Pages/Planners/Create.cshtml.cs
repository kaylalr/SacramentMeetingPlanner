using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Planners
{
    public class CreateModel : PageModel
    {
        private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

        public CreateModel(SacramentMeetingPlanner.Models.MeetingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Planner Planner { get; set; }

		//[HttpGet("/Create?action")]
		//public string Action { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

			//_context.Planner.Add(Planner);
			//await _context.SaveChangesAsync();
			var emptyPlanner = new Planner();

			if (await TryUpdateModelAsync<Planner>(
				emptyPlanner,
				"planner",   // Prefix for form value.
				p => p.MeetingDate, p => p.Bishopric, p => p.OpenPrayer, p => p.ClosePrayer))
			{
				_context.Planner.Add(emptyPlanner);
				await _context.SaveChangesAsync();
				//if (Request.Form["addSongs"].Clicked)
				//{
				//	return RedirectToPage("./Details");
				//}
				return RedirectToPage("./Index");
			}
			//if ( == "AddSongs")
			//if (Request.Form["addSongs"] == true)
			//{
			//	return RedirectToPage("./Details");
			//}
			return RedirectToPage("./Index");
        }

		//[HttpGet("/Create?action=")]
		public async Task<IActionResult> OnPostAddSongsAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			//_context.Planner.Add(Planner);
			//await _context.SaveChangesAsync();
			var emptyPlanner = new Planner();

			if (await TryUpdateModelAsync<Planner>(
				emptyPlanner,
				"planner",   // Prefix for form value.
				p => p.MeetingDate, p => p.Bishopric, p => p.OpenPrayer, p => p.ClosePrayer))
			{
				_context.Planner.Add(emptyPlanner);
				await _context.SaveChangesAsync();
				
				return RedirectToPage("/Songs/Create");
			}
			
			return RedirectToPage("/Songs/Create");
		}
	}
}