using System;

namespace JustinTsengSharp.Beta.Helpers
{
	public class DateTimeHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="start">要比對的起始日期</param>
		/// <param name="end">要比對的結束日期</param>
		/// <param name="isCompareOnlyDate">是否只比對日期</param>
		/// <returns>
		/// </returns>
		public static bool IsBetween(DateTime source, DateTime start, DateTime end, bool isCompareOnlyDate = false)
		{
			if (isCompareOnlyDate)
			{
				return source.Date >= start.Date && source.Date <= end.Date;
			}

			return source >= start && source <= end;
		}

		public static DateTime ToDateTimeOrDefault(string date, string time)
		{
			try
			{
				return Convert.ToDateTime(date + " " + time);
			}
			catch
			{
				return default;
			}
		}
		public static DateTime? ToDateTimeOrNull(string date, string time)
		{
			try
			{
				return Convert.ToDateTime(date + " " + time);
			}
			catch
			{
				return null;
			}
		}
	}
}
