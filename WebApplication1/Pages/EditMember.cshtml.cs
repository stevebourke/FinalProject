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
    public class EditMemberModel : PageModel
    {
        private readonly MemberDetailsContext _db;

        public EditMemberModel(MemberDetailsContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Member = await _db.Members.FindAsync(id);

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Member).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Member {Member.MemberID} not found!");
            }

            return RedirectToPage("/MemberConfirmation");
        }
    }
}