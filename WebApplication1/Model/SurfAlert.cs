using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    public class SurfAlert
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurfAlertID { get; set; }


        [Required]
        public int MemberID { get; set; }


        [Required]
        public string Location { get; set; }


        [Required]
        public decimal MinSwellHeight { get; set; }


        [Required]
        public decimal MaxSwellHeight { get; set; }


        [Required]
        public int MaxWind { get; set; }


        [Required]
        public string WindDirection { get; set; }


        [Required]
        public int MinPeriod { get; set; }


        public int GetMatchingConditions()
        {



        }

    }

}
