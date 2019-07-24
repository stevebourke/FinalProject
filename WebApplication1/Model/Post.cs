using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{

    public class Rootobject
    {  
        public int timestamp { get; set; }
        public int localTimestamp { get; set; }
        public int issueTimestamp { get; set; }
        public int fadedRating { get; set; }
        public int solidRating { get; set; }
        public Swell swell { get; set; }
        public Wind wind { get; set; }
        public Condition condition { get; set; }
        public Charts charts { get; set; }
    }

    public class Swell
    {
        public float absMinBreakingHeight { get; set; }
        public float absMaxBreakingHeight { get; set; }
        public int probability { get; set; }
        public string unit { get; set; }
        public int minBreakingHeight { get; set; }
        public int maxBreakingHeight { get; set; }
        public Components components { get; set; }
    }

    public class Components
    {
        public Combined combined { get; set; }
        public Primary primary { get; set; }
        public Secondary secondary { get; set; }
        public Tertiary tertiary { get; set; }
    }

    public class Combined
    {
        public float height { get; set; }
        public int period { get; set; }
        public float direction { get; set; }
        public string compassDirection { get; set; }
    }

    public class Primary
    {
        public float height { get; set; }
        public int period { get; set; }
        public float direction { get; set; }
        public string compassDirection { get; set; }
    }

    public class Secondary
    {
        public float height { get; set; }
        public int period { get; set; }
        public float direction { get; set; }
        public string compassDirection { get; set; }
    }

    public class Tertiary
    {
        public float height { get; set; }
        public int period { get; set; }
        public float direction { get; set; }
        public string compassDirection { get; set; }
    }

    public class Wind
    {
        public int speed { get; set; }
        public int direction { get; set; }
        public string compassDirection { get; set; }
        public int chill { get; set; }
        public int gusts { get; set; }
        public string unit { get; set; }
    }

    public class Condition
    {
        public int pressure { get; set; }
        public int temperature { get; set; }
        public string weather { get; set; }
        public string unitPressure { get; set; }
        public string unit { get; set; }
    }

    public class Charts
    {
        public string swell { get; set; }
        public string period { get; set; }
        public string wind { get; set; }
        public string pressure { get; set; }
        public string sst { get; set; }
    }


}


