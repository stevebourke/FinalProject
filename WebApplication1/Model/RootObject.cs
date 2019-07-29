using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{

    public class Rootobject
    {
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

    public class Swell
    {
        [Key]
        public float AbsMinBreakingHeight { get; set; }
        public float AbsMaxBreakingHeight { get; set; }
        public int Probability { get; set; }
        public string Unit { get; set; }
        public int MinBreakingHeight { get; set; }
        public int MaxBreakingHeight { get; set; }
        public Components Components { get; set; }
    }

    public class Components
    {
        public Combined Combined { get; set; }
        public Primary Primary { get; set; }
        public Secondary Secondary { get; set; }
        public Tertiary Tertiary { get; set; }
    }

    public class Combined
    {
        [Key]
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Primary
    {
        [Key]
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Secondary
    {
        [Key]
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Tertiary
    {
        [Key]
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Wind
    {
        [Key]
        public int Speed { get; set; }
        public int Direction { get; set; }
        public string CompassDirection { get; set; }
        public int Chill { get; set; }
        public int Gusts { get; set; }
        public string Unit { get; set; }
    }

    public class Condition
    {
        [Key]
        public int Pressure { get; set; }
        public int Temperature { get; set; }
        public string Weather { get; set; }
        public string UnitPressure { get; set; }
        public string Unit { get; set; }
    }

    public class Charts
    {
        [Key]
        public string Swell { get; set; }
        public string Period { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Sst { get; set; }
    }



}


