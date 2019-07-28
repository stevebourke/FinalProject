using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class MemberConfirmationModel : PageModel
    {

        private readonly MemberDetailsContext _db;


        public MemberConfirmationModel(MemberDetailsContext db)
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
    }
}