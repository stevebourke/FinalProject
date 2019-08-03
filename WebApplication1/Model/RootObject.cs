using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{

    public class RootObject
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

    [Owned]
    public class Swell
    {
        public float AbsMinBreakingHeight { get; set; }
        public float AbsMaxBreakingHeight { get; set; }
        public int Probability { get; set; }
        public string Unit { get; set; }
        public int MinBreakingHeight { get; set; }
        public int MaxBreakingHeight { get; set; }
        public Components Components { get; set; }
    }


    [Owned]
    public class Components
    {
        public Combined Combined { get; set; }
        public Primary Primary { get; set; }
        public Secondary Secondary { get; set; }
        public Tertiary Tertiary { get; set; }
    }



    [Owned]
    public class Combined
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    [Owned]
    public class Primary
    {
        public float Height { get; set; }
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
        public string Weather { get; set; }
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


