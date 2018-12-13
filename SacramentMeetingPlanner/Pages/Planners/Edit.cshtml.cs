using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Pages.Planners
{
	public class EditModel : PageModel
	{
		private readonly SacramentMeetingPlanner.Models.MeetingContext _context;

		public EditModel(SacramentMeetingPlanner.Models.MeetingContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Planner Planner { get; set; }
		public Song Songs { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				id = int.Parse(Request.Query["id"]);
				if (id == null)
				{
					return NotFound();
				}
			}

			//Planner = await _context.Planner.FirstOrDefaultAsync(m => m.PlannerId == id);
			//Student = await _context.Student.FindAsync(id);
			Planner = await _context.Planner.FindAsync(id);
			Songs = await _context.Songs.FindAsync(id);

			if (Planner == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			//if (id == null)
			//{
			//	id = int.Parse(Request.Query["id"]);
			//	if (id == null)
			//	{
			//		return NotFound();
			//	}
			//}

			var plannerToUpdate = await _context.Planner.FindAsync(id);

				if (await TryUpdateModelAsync<Planner>(
					plannerToUpdate,
					"planner",
					p => p.MeetingDate, p => p.Bishopric, p => p.OpenPrayer, p => p.ClosePrayer))
				{
					await _context.SaveChangesAsync();
					return RedirectToPage("./Index");
				}

			return Page();
		}

		public async Task<IActionResult> OnPostUpdateSongsAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var plannerToUpdate = await _context.Planner.FindAsync(id);

			//if (plannerToUpdate.MeetingDate != Planner.MeetingDate || Planner.Bishopric != plannerToUpdate.Bishopric || Planner.OpenPrayer != plannerToUpdate.OpenPrayer || Planner.ClosePrayer != plannerToUpdate.ClosePrayer)
			//{
				if (await TryUpdateModelAsync<Planner>(
					plannerToUpdate,
					"planner",
					p => p.MeetingDate, p => p.Bishopric, p => p.OpenPrayer, p => p.ClosePrayer))
				{
					await _context.SaveChangesAsync();
					return RedirectToPage("/Songs/Edit", new { id = plannerToUpdate.PlannerId });
				}
			//}

			return RedirectToPage("/Songs/Edit", new { id = plannerToUpdate.PlannerId });
		}


		private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.PlannerId == id);
        }
    }
}
