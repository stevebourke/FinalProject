using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{

    public class Member
    {

        //Create a unique ID for each member
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }



        //Using . in case anyone has an @ in their name!
        [Required]
        [Display(Name = "First Name *")]
        [RegularExpression(@".{2,80}", ErrorMessage = "First Name must be at least two characters")]
        public string FirstName { get; set; } = "";



        [Required]
        [Display(Name = "Last Name *")]
        [RegularExpression(@".{2,80}", ErrorMessage = "Last Name must be at least two characters")]
        public string LastName { get; set; } = "";


        //I was struggling a bit to come up with this regex - found this on the regexlib.com website
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?!.*\s).{7,19}$")]
        [Required]
        [Display(Name = "Password *")]
        public string Password { get; set; }



        public string Street { get; set; }



        [Required]
        [Display(Name = "Town *")]
        public string Town { get; set; }



        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^08\d{8}|\d{7}$", ErrorMessage = "Phone Number must be of " +
           "format 08-------- or 1234567")]
        public string PhoneNumber { get; set; }



        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^08\d{8}|\d{7}$", ErrorMessage = "Phone Number must be of " +
            "format 08-------- or 1234567")]
        public string AltNumber { get; set; }



        [Required]
        [Display(Name = "Email Address *")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        //Compare to first email entry
        [Required]
        [Display(Name = "Confirm Email Address *")]
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirm { get; set; }



        //Empty Constructor
        public Member()
        {

        }


    }


}

