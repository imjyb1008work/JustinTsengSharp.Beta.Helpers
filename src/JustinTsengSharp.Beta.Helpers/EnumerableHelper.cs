using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class EnumerableHelper
	{
		public static IEnumerable<TResult> ToPaged<TResult>(IEnumerable<TResult> source, int pageNumber, int pageSize)
		{
			return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public static List<TResult> ToPagedList<TResult>(IEnumerable<TResult> source, int pageNumber, int pageSize)
		{
			return ToPaged<TResult>(source, pageNumber, pageSize).ToList();
		}

		public static TResult[] ToPagedArray<TResult>(IEnumerable<TResult> source, int pageNumber, int pageSize)
		{
			return ToPaged<TResult>(source, pageNumber, pageSize).ToArray();
		}

		public static bool IsNullOrEmpty<TResult>(IEnumerable<TResult> source)
		{
			return source == null || !source.Any();
		}
	}
}
