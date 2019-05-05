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

    public static LineSegment Create(Point p1, Point p2)
    {
      return new LineSegment(p1, p2);
    }

    private object Slope()
    {
      if (pointTwo.x == pointOne.x)
        return null;
      else
        return (pointTwo.y - pointOne.y) / (pointTwo.x - pointOne.x);
    }

    private object yIntercept()
    {
      var slope = Slope();
      object intercept = null;
      if(slope != null)
        intercept = pointOne.y - (double)Slope() * pointOne.x;
      return intercept;
    }

    private object xIntercept()
    {
      var slope = Slope();
      object intercept = null;
      if (slope != null && (double)slope != 0)
        intercept = -1 * (double)yIntercept() / (double)slope;
      return intercept;
    }

    public double Length()
    {
      return pointOne.dist(pointTwo);
    }

    public double Angle()
    {
      var diffedPoint = pointTwo.sub(pointOne);
      var vector = diffedPoint.norm();
      var cosTheta = vector.x / vector.mag();
      var theta = Math.Acos(cosTheta);
      if(vector.y < 0)
        return 2 * Math.PI - theta;
      return theta;
    }

    public bool AboveLine(Point p)
    {
      var isAbove = false;
      var slope = Slope();
      if (slope != null)
        isAbove = p.y > (double)slope * p.x + (double)yIntercept();
      return isAbove;
    }

    public bool BelowLine(Point p)
    {
      var isBelow = false;
      var slope = Slope();
      if (slope != null)
        isBelow = p.y < (double)slope * p.x + (double)yIntercept();
      return isBelow;
    }

    public bool OnLeft(Point p)
    {
      var isLeft = false;
      var slope = Slope();
      if (slope == null )
        isLeft = p.x < pointOne.x;
      return isLeft;
    }

    public bool OnRight(Point p)
    {
      var isRight = false;
      var slope = Slope();
      if (slope == null)
        isRight = p.x > pointOne.x;
      return isRight;
    }

    public bool Parallel(LineSegment line)
    {
      var slopeLine = Slope();
      var slopeTwo = line.Slope();
      var isParallel = false;
      if (slopeLine != null && slopeTwo != null)
        isParallel = (double)slopeTwo == (double)slopeLine;
      if (slopeLine == slopeTwo)
        isParallel = true;
      return isParallel;
    }

    public bool MeetInMiddle(LineSegment line)
    {
      return Midpoint().Equals(line.Midpoint());
    }

    private Point Midpoint()
    {
      var xMid = (pointOne.x + pointTwo.x) / 2;
      var yMid = (pointOne.y + pointTwo.y) / 2;
      return Point.create(xMid, yMid);
    }

    public bool MeetAtTheEnd(LineSegment line)
    {
      return IntersectsAtPoint(line);
    }

    public bool DoNotMeet(LineSegment line)
    {
      var isParallel = Parallel(line);
      var intersects = IntersectFully(line) || IntersectsAtPoint(line);
      return !intersects ||
             (isParallel && yIntercept() != line.yIntercept()) ||
             (isParallel && xIntercept() != line.xIntercept());
    }

    private int[] Orientations(LineSegment line)
    {
      //orientations for general and special cases 
      int o1 = Orientation(pointOne, pointTwo, line.pointOne);
      int o2 = Orientation(pointOne, pointTwo, line.pointTwo);
      int o3 = Orientation(pointTwo, line.pointTwo, pointOne);
      int o4 = Orientation(pointTwo, line.pointTwo, pointTwo);
      return new int[] { o1, o2, o3, o4 };
    }

    //Orientation comes from slope subtractions
    private int Orientation(Point p, Point q, Point r)
    {
      double val = (q.y - p.y) * (r.x - q.x) -
                (q.x - p.x) * (r.y - q.y);
      //colinear if zero
      if (val == 0) return 0;
      // clock or counterclock wise 
      return (val > 0) ? 1 : 2;
    }

    private bool IntersectFully(LineSegment line)
    {
      var orientations = Orientations(line);
      return orientations[0] != orientations[1] && orientations[2] != orientations[3];
    }

    private bool IntersectsAtPoint(LineSegment line)
    {
      var orientations = Orientations(line);
      // Special Cases for colinearity of endpoints
      // pointOne, line.pointTwo and line.pointOne are colinear and line.pointOne lies on segment pointOneline.pointTwo 
      if (orientations[0] == 0 && OnLine(pointOne, line.pointOne, pointTwo))
        return true;
      // pointOne, line.pointTwo and line.pointTwo are colinear and line.pointTwo lies on segment pointOneline.pointTwo 
      if (orientations[1] == 0 && OnLine(pointOne, line.pointTwo, pointTwo))
        return true;
      // line.pointOne, line.pointTwo and pointOne are colinear and pointOne lies on segment line.pointOneline.pointTwo 
      if (orientations[2] == 0 && OnLine(line.pointOne, pointOne, line.pointTwo))
        return true;
      // line.pointOne, line.pointTwo and line.pointTwo are colinear and line.pointTwo lies on segment line.pointOneline.pointTwo 
      if (orientations[3] == 0 && OnLine(line.pointOne, pointTwo, line.pointTwo))
        return true;
      //No intersection
      return false;
    }

    //check if point lies on segment
    private bool OnLine(Point p, Point q, Point r)
    {
      if (q.x <= Math.Max(p.x, r.x) && q.x >= Math.Min(p.x, r.x) &&
          q.y <= Math.Max(p.y, r.y) && q.y >= Math.Min(p.y, r.y))
        return true;
      return false;
    }

    public string ToString()
    {
      return $"{pointOne.ToString()}, {pointTwo.ToString()}";
    }
  }
}
