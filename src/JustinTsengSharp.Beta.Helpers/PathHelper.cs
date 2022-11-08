using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JustinTsengSharp.Beta.Helpers
{
	public class PathHelper
	{
		public static string GetRandomFileNameWithoutExtension()
		{
			return Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
		}

		public static string[] GetRandomFilesNameWithoutExtension(int count)
		{
			return Enumerable.Range(1, count).Select(x => GetRandomFileNameWithoutExtension()).ToArray();
		}

		public static string Combine(params string[] paths)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var path in paths)
			{
				sb.Append(Path.Combine(sb.ToString(), path));
			}

			return sb.ToString();
		}
	}
}
