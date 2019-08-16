using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SurfProject.Model;

namespace SurfProject.Pages
{
    public class SignInModel : PageModel
    {

        private readonly MemberDetailsContext _db;

        public SignInModel(MemberDetailsContext db)
        {
            _db = db;
        }

        //The entered values will be checked against our database records
        [BindProperty]
        [Display(Name = "Email Address")]
        public string EmailSignIn { get; set; }


        [BindProperty]
        [Display(Name = "Password")]
        public string PasswordSignIn { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            //If _db.Members is empty it may come back as null and throw an exception - check for this
            if (_db.Members != null)
            {
                int listEmailResult = CheckEmailSignIn();


                //If email is in our database check that the password is right
                if (listEmailResult == 1)
                {
                    int listPasswordResult = CheckPasswordSignIn();


                    if (listPasswordResult == 1)
                    {
                        //Get the member id for this email address
                        var listEmail = _db.Members
                   .Where(x => x.Email == EmailSignIn)
                   .Select(x => x.MemberID);

                        int idSignIn = listEmail.First();

                        //Go to member page using member's id as route parameter
                        return RedirectToPage("MemberPage", new { id = idSignIn });
                    }

                    else
                    {
                        TempData["Message"] = "Forgotten your password? We can send a new one to you";
                        return Page();
                    }

                }

                //If the entered email address doesn't match any in the dataset, return same page with a message
                else
                {
                    TempData["Message"] = "This email address is not in our system - Please sign up";
                    return Page();
                }
            }

            //If there are no records in DBSet Members, return same page with a message
            else
            {
                TempData["Message"] = "This email address is not in our system - Please sign up";
                return Page();
            }
        }

        //Ensure that the user's email address, which is unique, is in our database
        public int CheckEmailSignIn()
        {
            int listEmailInt = 0;

            var listEmail = _db.Members
                   .Where(x => x.Email == EmailSignIn)
                   .Select(x => x);

            if (listEmail.Count() == 1)
            {
                listEmailInt = 1;
            }

            return listEmailInt;
        }

        //This method checks the dataset to ensure that the entered password for this user is correct
        public int CheckPasswordSignIn()
        {
            int listPasswordInt = 0;

            var listPassword = _db.Members
                  .Where(x => x.Email == EmailSignIn && x.Password == PasswordSignIn)
                  .Select(x => x);

            if (listPassword.Count() == 1)
            {
                listPasswordInt = 1;
            }

            return listPasswordInt;
        }
    }
}