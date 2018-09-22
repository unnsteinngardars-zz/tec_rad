using System;

namespace TecRad.Models.NewsItem
{
	public class NewsItem
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string ImgSource { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public DateTime PublishDate { get; set; }


		// Auto generated data for database

		public string ModifiedBy { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }

		public int AuthorId { get; set; }

		public int CategoryId { get; set; }
	}
}