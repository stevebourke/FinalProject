using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class EditSurfProfileModel : PageModel
    {
        private readonly MemberDetailsContext _db;

        public EditSurfProfileModel(MemberDetailsContext db)
        {
            _db = db;
        }

        [BindProperty]
        public SurfProfile SurfProfile { get; set; }

        public async Task<IActionResult>
    OnGetAsync(int id)
        {
            SurfProfile = await _db.SurfProfiles.FindAsync(id);

            if (SurfProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult>
            OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(SurfProfile).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Surf Profile {SurfProfile.SurfProfileID} not found!");
            }

            return RedirectToPage("/SurfProfileConfirmation");
        }
    }
}