using System;

namespace TecRad.Models.NewsItem
{
	public class NewsItemDetailDTO
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string ImgSource { get; set; }

		public string ShortDescription { get; set; }

		public string LongDescription { get; set; }

		public DateTime PublisDate { get; set; }
	}
}