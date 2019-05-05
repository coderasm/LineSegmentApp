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
      LineSegmentTest.LengthTest();
      LineSegmentTest.AngleTest();
      LineSegmentTest.AboveLineTest();
      LineSegmentTest.BelowLineTest();
      LineSegmentTest.OnRightTest();
      LineSegmentTest.OnLeftTest();
      LineSegmentTest.ParallelTest();
      LineSegmentTest.MeetInMiddleTest();
      LineSegmentTest.MeetAtEndTest();
      LineSegmentTest.DoesNotMeetTest();
      Console.ReadKey();
    }
  }
}
