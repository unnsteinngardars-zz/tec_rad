using System.ComponentModel.DataAnnotations;

namespace TecRad.Models.Category
{
	public class CategoryInputModel
	{
		[Required]
		[MaxLength(60)]
		public string Name { get; set; }
		public int ParentCategoryId { get; set; } = 0;

		public string Slug
		{
			get
			{
				return Name.Replace(" ", "-").ToLower();
			}
		}
	}
}