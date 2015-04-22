using System;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace PhotoHoarder
{
	/// <summary>
	/// Base class representing a photo.
	/// </summary>
	public abstract class Photo
	{
		/// <summary>
		/// The name of the file.
		/// </summary>
		public readonly string FileName;

		/// <summary>
		/// The Facebook ID
		/// </summary>
		public readonly string ID;

		/// <summary>
		/// The Facebook album ID.
		/// </summary>
		public readonly string AlbumID;

		/// <summary>
		/// Made available for cacheing.
		/// </summary>
		protected Image image;

		public Photo (string filename, string id, string albumID = null)
		{
			FileName = filename;
			ID = id;
			AlbumID = albumID;
		}

		/// <summary>
		/// Creates an Image object from the underlying source.
		/// </summary>
		/// <returns>The image async.</returns>
		public async Task<Image> GetImageAsync ()
		{
			if (image == null)
			{
				byte[] buffer;
				using (var reader = new StreamReader (GetStream (), Encoding.UTF8))
				{
					var strBuffer = await reader.ReadToEndAsync ();
					buffer = Encoding.UTF8.GetBytes (strBuffer);
				}

				using (var stream = new MemoryStream (buffer))
				{
					image = Image.FromStream (stream);
				}
			}

			return image;
		}

		protected abstract Stream GetStream();
	}
}

