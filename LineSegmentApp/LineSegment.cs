using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentApp
{
  class LineSegment
  {
    private Point pointOne;
    private Point pointTwo;
    private LineSegment(Point p1, Point p2)
    {
      pointOne = p1;
      pointTwo = p2;
    }

    public LineSegment Create(Point p1, Point p2)
    {
      return new LineSegment(p1, p2);
    }
  }
}
