using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JustinTsengSharp.Beta.Helpers
{
	public class HashHelper
	{
		public static string ToMD5AsString(string text, Encoding encoding = null, string format = "")
		{
			return Hashing(() => MD5.Create(), text, encoding == null ? Encoding.Default : encoding, format);
		}

		public static string ToMD5ForUTF8AsStringX2(string value)
		{
			return Hashing(() => MD5.Create(), value, Encoding.UTF8, "X2");
		}

		public static string ToSHA1AsString(string text, Encoding encoding, string format = "")
		{
			return Hashing(() => SHA1.Create(), text, encoding, format);
		}

		public static string ToSHA1ForUTF8AsStringX2(string value)
		{
			return Hashing(() => SHA1.Create(), value, Encoding.UTF8, "X2");
		}

		public static string ToSHA256AsString(string text, Encoding encoding, string format = "")
		{
			return Hashing(() => SHA256.Create(), text, encoding, format);
		}

		public static string ToSHA256ForUTF8AsStringX2(string value)
		{
			return Hashing(() => SHA256.Create(), value, Encoding.UTF8, "X2");
		}

		public static string ToSHA384AsString(string text, Encoding encoding, string format = "")
		{
			return Hashing(() => SHA384.Create(), text, encoding, format);
		}

		public static string ToSHA384ForUTF8AsStringX2(string value)
		{
			return Hashing(() => SHA384.Create(), value, Encoding.UTF8, "X2");
		}

		public static string ToSHA512AsString(string text, Encoding encoding, string format = "")
		{
			return Hashing(() => SHA512.Create(), text, encoding, format);
		}

		public static string ToSHA512ForUTF8AsStringX2(string value)
		{
			return Hashing(() => SHA512.Create(), value, Encoding.UTF8, "X2");
		}

		private static string Hashing(Func<HashAlgorithm> func, string value, Encoding encoding, string format)
		{
			using (var crypto = func())
			{
				return Hashing(value, crypto, encoding, format);
			}
		}

		private static string Hashing(string value, HashAlgorithm crypto, Encoding encoding, string foramt)
		{
			return string.Join
			(
				string.Empty,
				crypto.ComputeHash
				(
					encoding.GetBytes(value)
				)
				.Select
				(
					x => x.ToString(foramt)
				).ToArray()
			);
		}
	}
}
