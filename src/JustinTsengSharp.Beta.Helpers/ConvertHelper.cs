using System;

namespace JustinTsengSharp.Beta.Helpers
{
	public class ConvertHelper
	{
		public static byte ToByteOrDefault(object source , byte defaultValue = default)
		{
			try
			{
				return Convert.ToByte(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static short ToInt16OrDefault(object source, short defaultValue = default)
		{
			try
			{
				return Convert.ToInt16(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static int ToInt32OrDefault(object source, int defaultValue = default)
		{
			try
			{
				return Convert.ToInt32(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static long ToInt64OrDefault(object source, long defaultValue = default)
		{
			try
			{
				return Convert.ToInt64(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static float ToFloatOrDefault(object source , float defaultValue = default)
		{
			try
			{
				return Convert.ToSingle(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static double ToDoubleOrDefault(object source, double defaultValue = default)
		{
			try
			{
				return Convert.ToDouble(source);
			}
			catch (Exception)
			{
				return default;
			}
		}

		public static decimal ToDecimalOrDefault(object source, decimal defaultValue = default)
		{
			try
			{
				return Convert.ToDecimal(source);
			}
			catch (Exception)
			{
				return default;
			}
		}
	}
}
