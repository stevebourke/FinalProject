using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    
    public class SurfProfile
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurfProfileID { get; set; }


        [Required]
        public int MemberID { get; set; }


        [Required]
        public string Location { get; set; }


        [Required]
        public decimal MinWaveHeight { get; set; }


        [Required]
        public int MinPeriod { get; set; }


        [Required]
        public int SouthWindStrength { get; set; } = 0;


        [Required]
        public int NorthWindStrength { get; set; } = 0;


        [Required]
        public int WestWindStrength { get; set; } = 0;


        [Required]
        public int EastWindStrength { get; set; } = 0;



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

        public int GetAppWindStrength(RootObject r)
        {
            int ApplicableWindStrength = 0;

                if (45 < r.Wind.Direction && r.Wind.Direction < 135)
                { ApplicableWindStrength = WestWindStrength; }

                else if (135 < r.Wind.Direction && r.Wind.Direction < 225)
                { ApplicableWindStrength = NorthWindStrength; }

                else if (225 < r.Wind.Direction && r.Wind.Direction < 315)
                { ApplicableWindStrength = EastWindStrength; }

                else { ApplicableWindStrength = SouthWindStrength; }


            return ApplicableWindStrength;
        }



    }

}
