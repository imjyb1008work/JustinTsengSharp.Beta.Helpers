using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

namespace JustinTsengSharp.Beta.Helpers.Test
{
	[TestClass]
	public class UnitTest
	{
		private readonly Dictionary<string, string> _lookup = new Dictionary<string, string>
		{
			{ "Boolean", "bool" },
			{ "Boolean[]", "bool[]" },
			{ "Byte", "byte" },
			{ "Byte[]", "byte[]" },
			{ "Int16", "short" },
			{ "Int16[]", "short[]" },
			{ "Int32", "int" },
			{ "Int32[]", "int[]" },
			{ "Int64", "long" },
			{ "Int64[]", "long[]" },
			{ "Single", "float" },
			{ "Single[]", "float[]" },
			{ "Double", "double" },
			{ "Double[]", "double[]" },
			{ "Decimal", "decimal" },
			{ "Decimal[]", "decimal[]" },
			{ "String", "string" },
			{ "String[]", "string[]" },
			{ "Object", "object" },
			{ "Object[]", "object[]" },
		};

		[TestMethod]
		public void MyTestMethod()
		{
			IEnumerable<Type> types = typeof(SqlHelper).Assembly.GetTypes().Where(x => x.IsClass && x.IsPublic);

			foreach (var type in types)
			{
				Console.WriteLine(type.Name);
				foreach (var property in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
				{
					if (property.Name == "ToPagedArray" || 1 == 1)
					{
						var returnType = GetTypeInfo(property.ReturnType);

						var t = string.Empty;

						if (!string.IsNullOrWhiteSpace(returnType.Item2))
						{
							t = "<" + returnType.Item2 + ">";
						}

						Console.WriteLine($"{returnType.Item1} {property.Name}{t}({string.Join<string>(", ", property.GetParameters().Select(x => $"{GetTypeInfo(x.ParameterType).Item1} {x.Name}"))})");
					}
				}
				Console.WriteLine();
			}
		}

		private (string, string) GetTypeInfo(Type type)
		{
			var newType = Nullable.GetUnderlyingType(type) ?? type;

			var nullType = Nullable.GetUnderlyingType(type);

			if (newType.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
			{
				var args = type.GetGenericArguments();
				return (newType.Name.Replace("`1", "<" + GetTypeName(args[0].Name) + ">"), args[0].Name);
			}
			else if (newType.IsGenericType)
			{
				var args = type.GetGenericArguments();
				return (newType.Name.Replace("`1", "<" + GetTypeName(args[0].Name) + ">"), args[0].Name);
			}

			if (type.ContainsGenericParameters)
			{
				return (GetTypeName(newType.Name), type.BaseType == typeof(Array) ? GetTypeName(newType.Name.Replace("[]", string.Empty)) : GetTypeName(newType.Name));
			}
			else
			{
				return (GetTypeName(newType.Name), string.Empty);
			}

		}

		private string GetTypeName(string name)
		{
			if (_lookup.TryGetValue(name, out var result))
			{
				return result;
			}

			return name;
		}
	}
}
