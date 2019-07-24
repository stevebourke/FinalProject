using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "First Name")]
        [RegularExpression(@".{2,80}", ErrorMessage = "First Name must be at least two characters")]
        public string FirstName { get; set; } = "";



        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@".{2,80}", ErrorMessage = "Last Name must be at least two characters")]
        public string LastName { get; set; } = "";



        [Required]
        public string Street { get; set; }



        [Required]
        public string Town { get; set; }



        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^08\d{8}|\d{7}$", ErrorMessage = "Phone Number must be of " +
           "format 08-------- or 1234567")]
        public string PhoneNumber { get; set; }



        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^08\d{8}|\d{7}$", ErrorMessage = "Phone Number must be of " +
            "format 08-------- or 1234567")]
        public string AltNumber { get; set; }



        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        //Compare to first email entry
        [Required]
        [Compare("Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirm { get; set; }


        //Custom validation - it is bound to Monday but will make sure that at least one checkbox is checked
        [DaysPicked]
        [Display(Name = "Monday")]
        public bool IsMondayChecked { get; set; }


        [Display(Name = "Tuesday")]
        public bool IsTuesdayChecked { get; set; }


        [Display(Name = "Wednesday")]
        public bool IsWednesdayChecked { get; set; }


        [Display(Name = "Thursday")]
        public bool IsThursdayChecked { get; set; }


        [Display(Name = "Friday")]
        public bool IsFridayChecked { get; set; }


        [Display(Name = "Saturday")]
        public bool IsSaturdayChecked { get; set; }


        [Display(Name = "Sunday")]
        public bool IsSundayChecked { get; set; }




        //This will return the number of days selected
        public int GetNumberOfDays()
        {

            int count = 0;

            if (IsMondayChecked)
            {
                count++;
            }

            if (IsTuesdayChecked)
            {
                count++;
            }

            if (IsWednesdayChecked)
            {
                count++;
            }

            if (IsThursdayChecked)
            {
                count++;
            }
            if (IsFridayChecked)
            {
                count++;
            }

            if (IsSaturdayChecked)
            {
                count++;
            }

            if (IsSundayChecked)
            {
                count++;
            }

            return count;

        }



    }
}
