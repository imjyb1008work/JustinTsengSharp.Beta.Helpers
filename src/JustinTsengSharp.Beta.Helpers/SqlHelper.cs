using System;
using System.Collections.Generic;
using System.Data;
#if NET35
using System.Data.SqlClient;
#else
using Microsoft.Data.SqlClient;
#endif
using System.Linq;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class SqlHelper
	{
		public static DataTable GetDataTable(string connectionString, string cmdText, SqlParameter[] parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var da = GetSqlDataAdapter(cmdText, connectionString))
			{
				var dt = new DataTable();
				if (parameters != null)
				{
					da.SelectCommand.Parameters.AddRange(parameters);
				}
				da.SelectCommand.CommandTimeout = GetCommandTimeoutOrDefault(commandTimeout);
				da.SelectCommand.CommandType = GetCommandTimeoutOrDefault(commandType);
				da.Fill(dt);
				return dt;
			}
		}

		public static DataTable GetDataTable(string connectionString, string cmdText, IEnumerable<SqlParameter> parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var da = GetSqlDataAdapter(cmdText, connectionString))
			{
				var dt = new DataTable();
				if (parameters != null)
				{
					da.SelectCommand.Parameters.AddRange(parameters.ToArray());
				}
				da.SelectCommand.CommandTimeout = GetCommandTimeoutOrDefault(commandTimeout);
				da.SelectCommand.CommandType = GetCommandTimeoutOrDefault(commandType);
				da.Fill(dt);
				return dt;
			}
		}

		public static DataTable GetDataTable(string connectionString, string cmdText, object parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var da = GetSqlDataAdapter(cmdText, connectionString))
			{
				var dt = new DataTable();
				if (parameters != null)
				{
					da.SelectCommand.Parameters.AddRange(parameters == null ? null : parameters.GetType().GetProperties().Select(x => new SqlParameter(x.Name, x.GetValue(x, null))).ToArray());
				}
				da.SelectCommand.CommandTimeout = GetCommandTimeoutOrDefault(commandTimeout);
				da.SelectCommand.CommandType = GetCommandTimeoutOrDefault(commandType);
				da.Fill(dt);
				return dt;
			}
		}

		public static int ExecuteNonQuery(string connectionString, string cmdText, SqlParameter[] parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = GetSqlCommand(conn, cmdText, parameters, commandTimeout, commandType);
				return cmd.ExecuteNonQuery();
			}
		}
		public static int ExecuteNonQuery(string connectionString, string cmdText, IEnumerable<SqlParameter> parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = GetSqlCommand(conn, cmdText, parameters.ToArray(), commandTimeout, commandType);
				return cmd.ExecuteNonQuery();
			}
		}

		public static int ExecuteNonQuery(string connectionString, string cmdText, object parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (var conn = new SqlConnection(connectionString))
			{
				conn.Open();
				SqlCommand cmd = GetSqlCommand(conn, cmdText, parameters == null ? null : parameters.GetType().GetProperties().Select(x => new SqlParameter(x.Name, x.GetValue(x, null))).ToArray(), commandTimeout, commandType);
				return cmd.ExecuteNonQuery();
			}
		}

		private static SqlCommand GetSqlCommand(SqlConnection connection, string cmdText, SqlParameter[] parameters, int? commandTimeout = null, CommandType? commandType = null)
		{
			var cmd = new SqlCommand()
			{
				Connection = connection,
				CommandText = cmdText,
				CommandTimeout = GetCommandTimeoutOrDefault(commandTimeout),
				CommandType = GetCommandTimeoutOrDefault(commandType),
			};

			if (parameters != null)
			{
				cmd.Parameters.AddRange(parameters);
			}

			return cmd;
		}

		private static SqlDataAdapter GetSqlDataAdapter(string connectionString, string cmdText)
		{
			return new SqlDataAdapter(cmdText, connectionString);
		}

		private static int GetCommandTimeoutOrDefault(int? source)
		{
			return source.HasValue ? source.Value : 30;
		}

		private static CommandType GetCommandTimeoutOrDefault(CommandType? source)
		{
			return source.HasValue ? source.Value : CommandType.Text;
		}
	}
}
