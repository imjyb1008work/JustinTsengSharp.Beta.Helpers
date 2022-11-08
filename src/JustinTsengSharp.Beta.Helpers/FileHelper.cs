using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class FileHelper
	{
		public static void IfNotExistsCreate(string path)
		{
			if (!File.Exists(path))
			{
				File.Create(path);
			}
		}
	}
}
