using System;

namespace LineSegmentApp
{
  class LineSegmentTest
  {
    public static void LengthTest()
    {
      //Length Test
      var segment = LineSegment.Create(Point.create(1, -1), Point.create(4, -4));
      Console.WriteLine($"Segment: {segment.ToString()}");
      Console.WriteLine($"Length: {segment.Length()}");
    }

    public static void AngleTest()
    {
      //Angle Test
      var segment = LineSegment.Create(Point.create(1, -1), Point.create(4, -4));
      Console.WriteLine($"Segment: {segment.ToString()}");
      Console.WriteLine($"Angle: {segment.Angle() * 180 / Math.PI}");
    }

    //AboveLine Test
    public static void AboveLineTest()
    {
      var segment = LineSegment.Create(Point.create(1, -1), Point.create(4, -4));
      var points = new Point[] { Point.create(2, 0), Point.create(2, -3) };
      PrintAbove(segment, points);
    }

    private static void PrintAbove(LineSegment line, Point[] points)
    {
      foreach (var point in points)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Point: {point.ToString()}");
        var isAbove = line.AboveLine(point);
        if (isAbove)
          Console.WriteLine("Point is above segment");
        else
          Console.WriteLine("Point is not above segment");
      }
    }

    //BelowLine Test
    public static void BelowLineTest()
    {
      var segment = LineSegment.Create(Point.create(1, -1), Point.create(4, -4));
      var points = new Point[] { Point.create(2, 0), Point.create(2, -3) };
      PrintBelow(segment, points);
    }

    private static void PrintBelow(LineSegment line, Point[] points)
    {
      foreach (var point in points)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Point: {point.ToString()}");
        var isBelow = line.BelowLine(point);
        if (isBelow)
          Console.WriteLine("Point is below segment");
        else
          Console.WriteLine("Point is not below segment");
      }
    }

    //OnRight test
    public static void OnRightTest()
    {
      var segment = LineSegment.Create(Point.create(2, -2), Point.create(2, 2));
      var points = new Point[] { Point.create(3, 0), Point.create(1, 0) };
      PrintOnRight(segment, points);
    }

    private static void PrintOnRight(LineSegment line, Point[] points)
    {
      foreach (var point in points)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Point: {point.ToString()}");
        var isOnRight = line.OnRight(point);
        if (isOnRight)
          Console.WriteLine("Point is right of segment");
        else
          Console.WriteLine("Point is not right of segment");
      }
    }

    //OnLeft test
    public static void OnLeftTest()
    {
      var segment = LineSegment.Create(Point.create(2, -2), Point.create(2, 2));
      var points = new Point[] { Point.create(3, 0), Point.create(1, 0) };
      PrintOnLeft(segment, points);
    }

    private static void PrintOnLeft(LineSegment line, Point[] points)
    {
      foreach (var point in points)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Point: {point.ToString()}");
        var isOnLeft = line.OnLeft(point);
        if (isOnLeft)
          Console.WriteLine("Point is left of segment");
        else
          Console.WriteLine("Point is not left of segment");
      }
    }

    //Parallel test
    public static void ParallelTest()
    {
      var segment = LineSegment.Create(Point.create(1, 0), Point.create(3, 3));
      var segment1 = LineSegment.Create(Point.create(2, 1), Point.create(4, 4));
      var segment2 = LineSegment.Create(Point.create(-1, -2), Point.create(0, 2));
      var segments = new LineSegment[] { segment1, segment2 };
      PrintIsParallel(segment, segments);
    }

    private static void PrintIsParallel(LineSegment line, LineSegment[] segments)
    {
      foreach (var segment in segments)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Segment: {segment.ToString()}");
        var isParallel = line.Parallel(segment);
        if (isParallel)
          Console.WriteLine("Segments parallel");
        else
          Console.WriteLine("Segment not parallel");
      }
    }

    //MeetInMiddle test
    public static void MeetInMiddleTest()
    {
      var segment = LineSegment.Create(Point.create(0, 0), Point.create(4, 4));
      var segment1 = LineSegment.Create(Point.create(4, 0), Point.create(0, 4));
      var segment2 = LineSegment.Create(Point.create(4, 0), Point.create(0, 3));
      var segments = new LineSegment[] { segment1, segment2 };
      PrintMeetInMiddle(segment, segments);
    }

    private static void PrintMeetInMiddle(LineSegment line, LineSegment[] segments)
    {
      foreach (var segment in segments)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Segment: {segment.ToString()}");
        var meetsInMiddle = line.MeetInMiddle(segment);
        if (meetsInMiddle)
          Console.WriteLine("Segments meet in the middle");
        else
          Console.WriteLine("Segments do not meet in the middle");
      }
    }

    //MeetAtEnd test
    public static void MeetAtEndTest()
    {
      var segment = LineSegment.Create(Point.create(0, 0), Point.create(4, 4));
      var segment1 = LineSegment.Create(Point.create(0, 0), Point.create(-2, 2));
      var segment2 = LineSegment.Create(Point.create(4, 4), Point.create(2, 6));
      var segment3 = LineSegment.Create(Point.create(2, 2), Point.create(-1, 5));
      var segment4 = LineSegment.Create(Point.create(0, 1), Point.create(-3, 4));
      var segments = new LineSegment[] { segment1, segment2, segment3, segment4 };
      PrintMeetAtEnd(segment, segments);
    }

    private static void PrintMeetAtEnd(LineSegment line, LineSegment[] segments)
    {
      foreach (var segment in segments)
      {
        Console.WriteLine($"Segment: {line.ToString()}, Segment: {segment.ToString()}");
        var meetsAtEmd = line.MeetAtTheEnd(segment);
        if (meetsAtEmd)
          Console.WriteLine("Segments meet on end");
        else
          Console.WriteLine("Segments do not meet on end");
      }
    }

    //DoesNotMeet test
    public static void DoesNotMeetTest()
    {
      var segment = LineSegment.Create(Point.create(0, 0), Point.create(0, 5));
      var segment1 = LineSegment.Create(Point.create(1, 0), Point.create(1, 5));
      var segment2 = LineSegment.Create(Point.create(-2, 4), Point.create(2, 4));
      var segment3 = LineSegment.Create(Point.create(-2, 2), Point.create(2, 2));
      var segment4 = LineSegment.Create(Point.create(0, 1), Point.create(-3, 4));
      var segment5 = LineSegment.Create(Point.create(1, 1), Point.create(4, 4));
      PrintDoesNotMeet(segment, segment1);
      PrintDoesNotMeet(segment2, segment3);
      PrintDoesNotMeet(segment4, segment5);
      PrintDoesNotMeet(segment, segment2);
    }

    private static void PrintDoesNotMeet(LineSegment line, LineSegment segment)
    {

      Console.WriteLine($"Segment: {line.ToString()}, Segment: {segment.ToString()}");
      var doNotMeet = line.DoNotMeet(segment);
      if (doNotMeet)
        Console.WriteLine("Segments do not meet");
      else
        Console.WriteLine("Segments meet");
    }
  }
}
