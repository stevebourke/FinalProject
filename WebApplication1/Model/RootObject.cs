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


        //I was unsure of how to deal with unix timestamp - found this on stackoverflow
        //It will convert the timestamp to a more readable date and time
        public DateTime GetDate(int LocalTimestamp)
        {
            DateTime MyTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return MyTime.AddSeconds(LocalTimestamp);
        }


    }

    public class Swell
    {
        public float AbsMinBreakingHeight { get; set; }
        public float AbsMaxBreakingHeight { get; set; }
        public int Probability { get; set; }
        public string Unit { get; set; }
        public int MinBreakingHeight { get; set; }
        public int MaxBreakingHeight { get; set; }
        public Components Components { get; set; }


        //I put this simple method in here as I thought it would make for neater code - now I'm not so sure!
        public decimal GetAverageWaveHeight(int minWave, int maxWave)
        {
            decimal avgHeight = (minWave + maxWave) / 2;

            return avgHeight;
        }
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
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Primary
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Secondary
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Tertiary
    {
        public float Height { get; set; }
        public int Period { get; set; }
        public float Direction { get; set; }
        public string CompassDirection { get; set; }
    }

    public class Wind
    {
        public int Speed { get; set; }
        public int Direction { get; set; }
        public string CompassDirection { get; set; }
        public int Chill { get; set; }
        public int Gusts { get; set; }
        public string Unit { get; set; }
    }

    public class Condition
    {
        public int Pressure { get; set; }
        public int Temperature { get; set; }
        public string Weather { get; set; }
        public string UnitPressure { get; set; }
        public string Unit { get; set; }
    }

    public class Charts
    {
        public string Swell { get; set; }
        public string Period { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Sst { get; set; }
    }

}

