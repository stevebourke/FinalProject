using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class MemberPageModel : PageModel
    {
        //Initial signup greeting - message will be changed below if it is a return visit
        public string Greeting = "Thank you for signing up with us";


        //To communicate with the database...
        private readonly MemberDetailsContext _db;


        public MemberPageModel(MemberDetailsContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Member Member { get; set; }


        //This collection will be used to access the current surf profiles for this member - it will be filled below
        public ObservableCollection<SurfProfile> surfProfiles = new ObservableCollection<SurfProfile>();



        public async Task<IActionResult> OnGetAsync(int id)
        {
            //Add a cookie to welcome/welcome back the member
            string time = DateTime.Now.ToShortDateString();

            CookieOptions options = new CookieOptions();

            options.Expires = DateTime.Now.AddYears(1);

            Response.Cookies.Append("YourCookie", time, options);

            if (Request.Cookies["YourCookie"] != null)
            {
                Greeting = $"Welcome back, you haven't " +
                    $"aged a day since you were last here on {Request.Cookies["YourCookie"]}";
            }

            //Get the member based on the incoming id
            Member = await _db.Members.FindAsync(id);
           

            //Fill the collection of profiles for those profiles with this member id
            if (_db.SurfProfiles != null)
            {
                foreach (SurfProfile surf in _db.SurfProfiles)
                {
                    if (surf.MemberID == id)
                    {
                        surfProfiles.Add(surf);
                    }
                }

            }

            return Page();
        }
    }
}