using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class EditSurfProfileModel : PageModel
    {
        //To communicate with the database...
        private readonly MemberDetailsContext _db;


        public EditSurfProfileModel(MemberDetailsContext db)
        {
            _db = db;
        }


        [BindProperty]
        public SurfProfile SurfProfile { get; set; }




        //This list will be used to populate our dropdown list of locations
        public List<SelectListItem> LocationList { get; set; } =

            new List<SelectListItem>
            {
                new SelectListItem("Inch", "Inch" ),
                new SelectListItem("Rossbeigh", "Rossbeigh" ),

            };



        public async Task<IActionResult>
            OnGetAsync(int id)
        {
            //Use the surfprofile ID which was passed in to retrieve the relevant surf profile from the database
            SurfProfile = await _db.SurfProfiles.FindAsync(id);

            return Page();
        }

        public async Task<IActionResult>
            OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
               
            
            //Edited surf profile is reinserted into database
            _db.Attach(SurfProfile).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Surf Profile {SurfProfile.SurfProfileID} not found!");
            }

            return RedirectToPage("/MemberPage", new { id = SurfProfile.MemberID });
        }
    }
}