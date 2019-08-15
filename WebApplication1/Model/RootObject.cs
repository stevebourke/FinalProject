using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    [Table("SurfReport")]
    public class RootObject
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ReportID")]
        [Key]
        public int ReportID { get; set; }

        public int Timestamp { get; set; }
        public int LocalTimestamp { get; set; }
        public int IssueTimestamp { get; set; }
        public int FadedRating { get; set; }
        public int SolidRating { get; set; }
        public Swell Swell { get; set; }
        public Wind Wind { get; set; }
        public Condition Condition { get; set; }
        public Charts Charts { get; set; }

    }

    [ComplexType]
    [Owned]
    public class Swell
    {
        public decimal MinBreakingHeight { get; set; }
        public float AbsMinBreakingHeight { get; set; }
        public decimal MaxBreakingHeight { get; set; }
        public float AbsMaxBreakingHeight { get; set; }
        public string Unit { get; set; }
        public Component Component { get; set; }
    }

    [ComplexType]
    [Owned]
    public class Component
    {
        public Component()
        { Combined = new Combined(); }


        public Combined Combined { get; set; }
        public Primary Primary { get; set; }
        public Secondary Secondary { get; set; }
        public Tertiary Tertiary { get; set; }
    }

    [Owned]
    [ComplexType]
    public class Combined
    {
        public Combined()
        { Period = new int(); }

        public float Height { get; set; }
        [Column("Swell_Component_Combined_Period")]
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    [Owned]
    public class Primary
    {
        public decimal Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    [Owned]
    public class Secondary
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    [Owned]
    public class Tertiary
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    [Owned]
    [ComplexType]
    public class Wind
    {
        public int Speed { get; set; }
        public int Direction { get; set; }
        public string CompassDirection { get; set; }
        public int Chill { get; set; }
        public int Gusts { get; set; }
        public string Unit { get; set; }
    }

    [Owned]
    public class Condition
    {
        public int Pressure { get; set; }
        public int Temperature { get; set; }
        public string UnitPressure { get; set; }
        public string Unit { get; set; }
    }

    [Owned]
    public class Charts
    {
        public string Swell { get; set; }
        public string Period { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Sst { get; set; }
    }
}

