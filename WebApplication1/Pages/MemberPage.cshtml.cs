using System;
using System.Collections.Generic;
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

        public string Greeting = "Thank you for signing up with us";


        private readonly MemberDetailsContext _db;


        public MemberPageModel(MemberDetailsContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Member Member { get; set; }

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


            Member = await _db.Members.FindAsync(id);


            if (Member == null)
            {
                return NotFound();
            }
            return Page();

            
        }
    }
}