using NUnit.Framework;
using System;
using PhotoHoarder;
using System.Drawing;

namespace PhotoHoarderTests
{
	[TestFixture()]
	public abstract class PhotoTest
	{
		public readonly static Image TestImage;
		protected Photo photo;

		static PhotoTest()
		{
			TestImage = Image.FromFile (@"../../bird.jpeg");
		}

		[Test()]
		public void TestCase ()
		{

		}
	}
}

