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
            if (From > range.To || range.From > To)
            {
                return null;
            }

            return new Range(Math.Max(range.From, From), Math.Min(range.To, To));
        }

        public Range[] GetUnion(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                double min = Math.Min(From, range.From);
                double max = Math.Max(To, range.To);

                return new Range[] { new Range(min, max) };
            }

            if (range.From > To)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            return new Range[] { new Range(range.From, range.To), new Range(From, To) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                if (range.From > From && range.To >= To)
                {
                    return new Range[] { new Range(From, range.From) };
                }

                if (range.From <= From && range.To < To)
                {
                    return new Range[] { new Range(range.To, To) };
                }

                if (range.From > From && range.To < To)
                {
                    return new Range[] { new Range(From, range.From), new Range(range.To, To) };
                }

                return new Range[] { };
            }

            return new Range[] { new Range(From, To) };
        }

        public static void Print(Range[] ranges)
        {
            StringBuilder sb = new StringBuilder();

            if (ranges.Length == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            sb.Append("[");
            sb.Append("(" + ranges[0].From + "; " + ranges[0].To + ")");

            for (int i = 1; i < ranges.Length; i++)
            {
                sb.Append(", (");
                sb.Append(ranges[i].From + "; " + ranges[i].To + ")");
            }

            sb.Append("]");

            Console.WriteLine(sb);
        }

        public override string ToString()
        {
            return string.Format("[({0}; {1})]", From, To);
        }
    }
}
