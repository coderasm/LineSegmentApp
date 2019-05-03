﻿using System;
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
      if (slope == null)
        isLeft = p.x < (p.y - (double)yIntercept()) / (double)slope;
      return isLeft;
    }

    public bool OnRight(Point p)
    {
      var isRight = false;
      var slope = Slope();
      if (slope == null)
        isRight = p.x > (p.y - (double)yIntercept()) / (double)slope;
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

    }

    private Point Midpoint()
    {
      var dist = pointOne.dist(pointTwo);
      var mid = dist / 2;
      var x = 
    }
  }
}
