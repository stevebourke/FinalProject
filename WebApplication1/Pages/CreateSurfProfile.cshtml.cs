using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class CreateSurfProfileModel : PageModel
    {
        private readonly SurfProfileContext _db;


        public CreateSurfProfileModel(SurfProfileContext db)
        {
            _db = db;
        }


        //Feed the details back into the surf alert class

        [BindProperty]
        public SurfProfile SurfProfile { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {

            //If model state is valid pass the details of the member surf preferences into the
            //database and redirect the page
            if (ModelState.IsValid)
            {
                _db.SurfProfiles.Add(SurfProfile);
                await _db.SaveChangesAsync();
                return RedirectToPage("Confirmation", new { id = SurfProfile.MemberID });
            }

            //If not valid the page will persist until it is filled out correctly
            else return Page();

        }
    }
}