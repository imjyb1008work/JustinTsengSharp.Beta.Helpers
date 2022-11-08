using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustinTsengSharp.Beta.Helpers.Test
{
	[TestClass]
	public class HashHelperUnitTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var actual = HashHelper.ToMD5ForUTF8AsStringX2("ABC");
			Assert.AreEqual("902FBDD2B1DF0C4F70B4A5D23525E932", actual);
		}

		[TestMethod]
		public void TestMethod2()
		{
			var actual = HashHelper.ToMD5AsString("ABC");
			Assert.AreEqual("902FBDD2B1DF0C4F70B4A5D23525E932", actual);
		}

		[TestMethod]
		public void TestMethod3()
		{
			var a = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.ASCII, "X2");
			var b = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.UTF8, "X2");
			Assert.AreEqual(a, b);
		} 
		
		[TestMethod]
		public void TestMethod4()
		{
			var a = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.Default, "X2");
			var b = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.UTF8, "X2");
			Assert.AreEqual(a, b);
		}

		[TestMethod]
		public void TestMethod5()
		{
			var a = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.Default, "X2");
			var b = HashHelper.ToMD5AsString("㏀ずㅡ겠", Encoding.GetEncoding(950), "X2");
			Assert.AreEqual(a, b);
		}
	}
}
