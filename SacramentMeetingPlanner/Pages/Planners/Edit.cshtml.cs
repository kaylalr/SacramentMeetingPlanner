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
		public ICollection<Song> Songs { get; set; }
		public IList<Song> Song { get; set; }
		public ICollection<Bishopric> Bishopric { get; set; }


		public async Task<IActionResult> OnGetAsync(int? id)
		{
			Bishopric = _context.Bishopric.Where(b => b.Active == true).ToList();

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
			Planner = await _context.Planner.FirstOrDefaultAsync(m => m.PlannerId == id);
			//Songs = await _context.Songs.FindAsync(Songs.PlannerId == Planner.PlannerId);

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
					p => p.MeetingDate, p => p.BishopricId, p => p.OpenPrayer, p => p.ClosePrayer))
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

			//if (id == null)
			//{
			//	id = int.Parse(Request.Query["id"]);
			//}

			//var plannerToUpdate = await _context.Planner.FindAsync(id);

			////if (plannerToUpdate.MeetingDate != Planner.MeetingDate || Planner.Bishopric != plannerToUpdate.Bishopric || Planner.OpenPrayer != plannerToUpdate.OpenPrayer || Planner.ClosePrayer != plannerToUpdate.ClosePrayer)
			////{
			//	if (await TryUpdateModelAsync<Planner>(
			//		plannerToUpdate,
			//		"planner",
			//		p => p.MeetingDate, p => p.BishopricId, p => p.OpenPrayer, p => p.ClosePrayer))
			//	{
			//		await _context.SaveChangesAsync();
			//		return RedirectToPage("/Songs/Edit", new { id = plannerToUpdate.PlannerId });
			//	}
			//}
			var plannerToUpdate = await _context.Planner.FindAsync(id);

			if (await TryUpdateModelAsync<Planner>(
				plannerToUpdate,
				"planner",
				p => p.MeetingDate, p => p.BishopricId, p => p.OpenPrayer, p => p.ClosePrayer))
			{
				await _context.SaveChangesAsync();
				//Songs = await _context.Songs.ToListAsync();
				//foreach (var sng in Songs) {
				//	Song = await _context.Songs.FindAsync(sng.PlannerId == id);
				//}
				//Song = await _context.Songs.Where(s => s.PlannerId == id).FirstOrDefaultAsync();
				//Songs = await _context.Songs.Where(s => s.PlannerId == id).ToListAsync();
				//foreach (var sng in Songs)
				//{
				//	return RedirectToPage("/Songs/Edit", new { id = sng.SongId });
				//}

				//var getSong = _context.Model.FindEntityType(typeof(Song)).FindPrimaryKey().Properties[0];
				//var otherGetSong = _context.Songs.Include(s => s.PlannerId).FirstOrDefault(e => EF.Property<int>(e, getSong.Name) == id);
				//return RedirectToPage("/Songs/Edit", new { id = otherGetSong.SongId });
				Song = await _context.Songs.ToListAsync();
				foreach (var sng in Song)
				{
					if (sng.PlannerId == id)
					{
						return RedirectToPage("/Songs/Edit", new { id = sng.SongId });
					}
				}
				//take this out when i figure out how to have a add songs and a edit songs button???
				return RedirectToPage("/Songs/Create", new { id = plannerToUpdate.PlannerId });

			}

			//return RedirectToPage("/Songs/Edit", new { id = plannerToUpdate.PlannerId });
			//Songs = await _context.Songs.Where(s => s.PlannerId == id).ToListAsync();
			//foreach (var sng in Songs)
			//{
			//	return RedirectToPage("/Songs/Edit", new { id = sng.SongId });
			//}
			//return RedirectToPage("/Songs/Edit");
			Song = await _context.Songs.ToListAsync();
			foreach (var sng in Song)
			{
				if (sng.PlannerId == id)
				{
					return RedirectToPage("/Songs/Edit", new { id = sng.SongId });
				}
			}
			return Page();
		}


		private bool PlannerExists(int id)
        {
            return _context.Planner.Any(e => e.PlannerId == id);
        }
    }
}
