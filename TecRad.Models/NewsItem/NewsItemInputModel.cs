using System;
using System.ComponentModel.DataAnnotations;

namespace TecRad.Models.NewsItem
{
	public class NewsItemInputModel
	{
		[Required]
		public string Title { get; set; }

		[Required]
		[Url]
		public string ImgSource { get; set; }

		[Required]
		[MaxLength(50)]
		public string ShortDescription { get; set; }

		[MinLength(50)]
		[MaxLength(255)]
		public String LongDescription { get; set; }

		[Required]
		public DateTime PublishDate { get; set; }
	}
}