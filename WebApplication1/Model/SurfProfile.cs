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
        [Display(Name = "Minimum Wave Height (feet)")]
        public decimal MinWaveHeight { get; set; }


        [Required]
        [Display(Name = "Minimum Wave Period (seconds)")]
        public int MinPeriod { get; set; }


        [Required]
        [Display(Name = "Maximum Wind if Southerly (mph)")]
        public int SouthWindStrength { get; set; } = 0;


        [Required]
        [Display(Name = "Maximum Wind if Northerly (mph)")]
        public int NorthWindStrength { get; set; } = 0;


        [Required]
        [Display(Name = "Maximum Wind if Westerly (mph)")]
        public int WestWindStrength { get; set; } = 0;


        [Required]
        [Display(Name = "Maximum Wind if Easterly (mph)")]
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


        //Empty Constructor
        public SurfProfile()
        {

        }



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



        //Wind direction is cut into four segments, e.g. sw to se is one segment.
        //Check incoming forecast's wind direction...member has given 
        //different max wind strength value for each direction
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




        //Check whether the member wants a forecast for the day of the week of a particular forecast
        public bool IsDayIncluded(RootObject r)
        {
            string forecastDay = r.GetDate(r.LocalTimestamp).DayOfWeek.ToString();

            bool includeDay = false;

            switch (forecastDay)
            {
                case "Monday":

                    if (IsMondayChecked) { includeDay = true; }

                    break;

                case "Tuesday":

                    if (IsTuesdayChecked) { includeDay = true; }

                    break;

                case "Wednesday":

                    if (IsWednesdayChecked) { includeDay = true; }

                    break;

                case "Thursday":

                    if (IsThursdayChecked) { includeDay = true; }

                    break;

                case "Friday":

                    if (IsFridayChecked) { includeDay = true; }

                    break;

                case "Saturday":

                    if (IsSaturdayChecked) { includeDay = true; }

                    break;

                case "Sunday":

                    if (IsSundayChecked) { includeDay = true; }

                    break;
            }

            return includeDay;
        }



        //This method returns only the forecasts whose conditions match those of the surf profile
        public List<RootObject> GetFilteredList(List<RootObject> rootObjects)
        {
            List<RootObject> FilteredList = rootObjects

              .Where(x => x.Swell.Components.Combined.Period > MinPeriod

                      && x.Wind.Speed <= GetAppWindStrength(x)

                      && x.Swell.GetAverageWaveHeight(x.Swell.MinBreakingHeight, x.Swell.MaxBreakingHeight) >= MinWaveHeight

                      && IsDayIncluded(x) == true)

                      .Select(x => x).ToList();

            return FilteredList;

        }


        //Link to the database again for use in the method below
        private readonly MemberDetailsContext _db;


        public SurfProfile(MemberDetailsContext db)
        {

            _db = db;
        }


        //Here we are doing a similar search as above to return all other members for whom the forecast
        //matches their criteria
        public Dictionary<int, List<SurfProfile>> GetPeersList(List<RootObject> roots)
        {

            Dictionary<int, List<SurfProfile>> dictionary = new Dictionary<int, List<SurfProfile>>();

            List<SurfProfile> PeersList = new List<SurfProfile>();


            for (int i = 0; i < 8; i++)
            {
                var tempList = _db.SurfProfiles

                .Where(x => x.Location == Location //ensure that the location matches the location for this profile

                && x.MemberID != MemberID          //do not return the member back himself in the list!

              && roots[i].Swell.Components.Combined.Period > x.MinPeriod

              && roots[i].Wind.Speed <= x.GetAppWindStrength(roots[i])

              && roots[i].Swell.GetAverageWaveHeight(roots[i].Swell.MinBreakingHeight, roots[i].Swell.MaxBreakingHeight) >= x.MinWaveHeight

              && x.IsDayIncluded(roots[i]) == true)

              .Select(x => x).ToList();

                if (tempList.Count() > 0)                                 //Do not add an empty list

                {
                    dictionary.Add(roots[i].LocalTimestamp, tempList);    //On each iteration add the results to our persisting list
                }
            }

                

            return dictionary;
        }
    }

}
