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
        //To communicate with the database...
        private readonly MemberDetailsContext _db;


        public CreateSurfProfileModel(MemberDetailsContext db)
        {
            _db = db;
        }


        //Feed the details back into the surf alert class

        [BindProperty]
        public SurfProfile SurfProfile { get; set; }


        //Use the member id passed in via route parameter to fill surfprofile.memberID value
        [BindProperty]
        public int spMemberID { get; set; }



        //This list will be used to populate our dropdown list of locations
        public List<SelectListItem> LocationList { get; set; } =

            new List<SelectListItem>
            {
                new SelectListItem("Inch", "Inch" ),
                new SelectListItem("Rossbeigh", "Rossbeigh" ),

            };



        public async Task<IActionResult> OnGetAsync(int id)
        {
            spMemberID = id;

           
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

           


            //If model state is valid pass the details of the member surf preferences into the
            //database and redirect the page, while passing along member ID again
            if (ModelState.IsValid)
            {

                //Do not allow a member to make more than one profile for each location
                if (_db.SurfProfiles != null)
                {
                    foreach (var surf in _db.SurfProfiles)
                    {
                        
                        //Add to list if location and member ID of new entry is the same as a record already in the database
                            var list = _db.SurfProfiles
                        .Where(x => x.Location == SurfProfile.Location && x.MemberID == SurfProfile.MemberID)
                        .Select(x => x);


                            //If location supplied for this member is already in the database then return the same page with the message below
                            if (list.Count() > 0)
                            {

                                TempData["Message"] = "You already have a profile for this location";
                                return Page();
                            }
                        
                    }
                }

                //If all ok...
                _db.SurfProfiles.Add(SurfProfile);
                await _db.SaveChangesAsync();
                return RedirectToPage("MemberPage", new { id = SurfProfile.MemberID });
            }

            //If not valid the page will persist until it is filled out correctly
            else return Page();

        }


    }
}