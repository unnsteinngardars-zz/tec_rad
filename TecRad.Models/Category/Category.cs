using System;

namespace TecRad.Models.Category
{
	public class Category : HyperMediaModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Slug { get; set; }

		public int ParentCategoryId { get; set; }

		public string ModifiedBy { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }
	}
}