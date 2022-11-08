using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class ConnStrHelper : ConnectionStringHelper
	{

	}

	public class ConnectionStringHelper
	{
		public static string GetConnectionString(string dataSource, string initialCatalog, string userId, string password)
		{
			return $"Data Source={dataSource}; Initial Catalog={initialCatalog}; User ID={userId}; password={password}";
		}
	}
}
