using System;

namespace TecRad.Models.Author
{
	public class Author : HyperMediaModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string ProfileImgSource { get; set; }

		public string Bio { get; set; }

		public string ModifiedBy { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}