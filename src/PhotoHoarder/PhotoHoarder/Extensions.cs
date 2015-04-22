using System;
using System.Security.Cryptography;
using System.Drawing;

namespace PhotoHoarder
{
	internal static class Extensions
	{
		public static long CalculateHash(this Image image)
		{
			var md5 = MD5.Create ();
			//md5.ComputeHash(
			throw new Exception ();
		}
	}
}

