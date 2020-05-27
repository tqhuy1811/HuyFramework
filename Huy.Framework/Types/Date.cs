using System;

namespace Huy.Framework.Types
{
	public class Date: IEquatable<Date>, IComparable<Date>
	{
		public Date(
			int day,
			int month,
			int year)
		{
			Day = day;
			Month = month;
			Year = year;
		}

		public int Day { get; }
		public int Month { get;}
		public int Year { get; }

		public bool Equals(Date other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Day == other.Day && Month == other.Month && Year == other.Year;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Date) obj);
		}

		public static bool operator <=(Date l, Date r)
		{
			return l.CompareTo(r) == -1 || l.CompareTo(r) == 0;
		}
		
		public static bool operator >=(Date l, Date r)
		{
			return l.CompareTo(r) == 1 || l.CompareTo(r) == 0;
		}

		public static bool operator <(Date l, Date r)
		{
			return l.CompareTo(r) == -1;
		}

		public static bool operator >(Date l, Date r)
		{
			return l.CompareTo(r) == 1;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Day, Month, Year);
		}

		public int CompareTo(Date other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			
			var yearComparison = Year.CompareTo(other.Year);
			
			if (yearComparison != 0)
				return yearComparison * -1;
			
			var monthComparison = Month.CompareTo(other.Month);

			if (monthComparison != 0)
				return monthComparison * -1;
			
			return Day.CompareTo(other.Day) * -1;
		}
	}
}