using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class IndexModel : PageModel
    {


        private readonly MemberContext _db;


        public IndexModel(MemberContext db)
        {
            _db = db;
        }


        //Feed the details back into our member class

        [BindProperty]
        public Member Member { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {

            //If model state is valid pass the details of the applicant into the temporary
            //database and redirect to the confirmation page
            if (ModelState.IsValid)
            {
                _db.Members.Add(Member);
                await _db.SaveChangesAsync();
                return RedirectToPage("Confirmation", new { id = Member.MemberID });
            }

            //If not valid the page will persist until it is filled out correctly
            else return Page();

        }
    }
}
