using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class CreateSurfProfileModel : PageModel
    {
        private readonly MemberDetailsContext _db;


        public CreateSurfProfileModel(MemberDetailsContext db)
        {
            _db = db;
        }


        //Feed the details back into the surf alert class

        [BindProperty]
        public SurfProfile SurfProfile { get; set; }


        //This list will be used to populate our dropdown list of locations
        public List<SelectListItem> LocationList { get; set; } =

            new List<SelectListItem>
            {
                new SelectListItem("Inch", "Inch" ),
                new SelectListItem("Rossbeigh", "Rossbeigh" ),

            };


        //Use the member id passed in via route parameter to fill surfprofile.memberID value
        [BindProperty]
        public int spMemberID { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            spMemberID = id;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            //If model state is valid pass the details of the member surf preferences into the
            //database and redirect the page
            if (ModelState.IsValid)
            {
                _db.SurfProfiles.Add(SurfProfile);
                await _db.SaveChangesAsync();
                return RedirectToPage("SurfProfileConfirmation", new { id = SurfProfile.MemberID });
            }

            //If not valid the page will persist until it is filled out correctly
            else return Page();

        }
    }
}