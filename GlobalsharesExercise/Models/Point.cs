using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalsharesExercise.Models
{
    public class Point
    {
        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public uint X { get; set; }
        public uint Y { get; set; }
    }
}
