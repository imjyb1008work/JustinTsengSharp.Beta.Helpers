using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class StringHelper
	{
		public static bool IsNullOrEmpty(string source)
		{
			return string.IsNullOrEmpty(source);
		}

		/// <summary>
		/// 此方法參考至微軟 string.IsNullOrWhiteSpace(String value) 的原始碼 
		/// .net framework 3.5 並沒有實作 string.IsNullOrWhiteSpace(String value) 此方法
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(string source)
		{
			if (source == null) return true;

			for (int i = 0; i < source.Length; i++)
			{
				if (!Char.IsWhiteSpace(source[i])) return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="length"></param>
		/// <returns>
		/// 若發生例外則回傳string.Empty
		/// </returns>
		public string LeftOrEmpty(string source, int length)
		{
			try
			{
				return source.Substring(0, length);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				return string.Empty;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="length"></param>
		/// <returns>
		/// 若發生例外則回傳string.Empty
		/// </returns>
		public string RightOrEmpty(string source, int length)
		{
			try
			{
				return source.Substring(0, length);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				return string.Empty;
			}
		}
	}
}
