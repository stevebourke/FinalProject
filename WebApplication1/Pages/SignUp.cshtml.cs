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
    public class SignUpModel : PageModel
    {
        public string Greeting = "Please fill in your details below - Required fields are marked with an asterisk";

        private readonly MemberDetailsContext _db;


        public SignUpModel(MemberDetailsContext db)
        {
            _db = db;
        }


        //Feed the details back into our Member class

        [BindProperty]
        public Member Member { get; set; }



        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)

            {
                //If _db.Members is empty it may come back as null and throw an exception - check for this
                if (_db.Members != null)
                {

                    //Search existing entries in Members table for the same email address just entered by an applicant -
                    //email address must be unique
                    var list = _db.Members
                    .Where(x => x.Email == Member.Email)
                    .Select(x => x);


                    //If email address supplied is already in the database then return the same page with the message below
                    if (list.Count() > 0)
                    {

                        TempData["Message"] = "This email address is already in our system";
                        return Page();
                    }
                }
            
                //If all is ok, add the new member to the dataset Members, and go to confirmation page
                _db.Members.Add(Member);


                await _db.SaveChangesAsync();
                return RedirectToPage("MemberPage", new { id = Member.MemberID });

            }

            //If not valid the page will persist until it is filled out correctly
            else return Page();

            }
        }
    }