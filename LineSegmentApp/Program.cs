using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Angle Test
      var segment = LineSegment.Create(Point.create(1, -1), Point.create(4, -4));
      Console.WriteLine(segment.Angle() * 180 / Math.PI);
      Console.ReadKey();
    }
  }
}
