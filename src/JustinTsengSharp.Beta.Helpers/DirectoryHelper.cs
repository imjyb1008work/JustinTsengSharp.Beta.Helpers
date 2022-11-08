using System.IO;

namespace JustinTsengSharp.Beta.Helpers
{
	public class DirectoryHelper

	{
		public static void IfNotExistsCreateDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}

