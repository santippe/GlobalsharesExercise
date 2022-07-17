using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalsharesExercise.Models
{
    public class LandingPlatform
    {
        public LandingPlatform() { }

        public LandingPlatform(Point upperLeftCorner, Point lowerRightCorner)
        {
            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;
        }

        public Point UpperLeftCorner { get; set; }
        public Point LowerRightCorner { get; set; }
    }
}
