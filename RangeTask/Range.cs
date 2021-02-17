using System;
using System.Text;

namespace RangeTask
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (From >= range.To || range.From >= To)
            {
                return null;
            }

            return new Range(Math.Max(range.From, From), Math.Min(range.To, To));
        }

        public Range[] GetUnion(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            }

            if (range.From > To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(range.From, range.To), new Range(From, To) };
        }

        public Range[] GetDifference(Range range)
        {
            if ((To <= range.To) && (From >= range.From))
            {
                return new Range[] { };
            }

            if ((From >= range.To) || (range.From >= To))
            {
                return new Range[] { new Range(From, To) };
            }

            if ((To > range.To) && (From < range.From))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (From < range.From)
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(range.To, To) };
        }

        private static string GetRangesArrayElement(Range[] ranges, int index)
        {
            if (ranges.Length == 0)
            {
                return null;
            }

            return string.Join(";", ranges[index]);
        }

        public static void Print(Range[] ranges)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append(GetRangesArrayElement(ranges, 0));

            for (int i = 1; i < ranges.Length; i++)
            {
                sb.Append(",");
                sb.Append(GetRangesArrayElement(ranges, i));
            }

            sb.Append("]");

            Console.WriteLine(sb);
        }

        public override string ToString()
        {
            return string.Format("({0}; {1})", From, To);
        }
    }
}
