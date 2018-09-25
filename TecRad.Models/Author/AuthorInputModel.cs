using System.ComponentModel.DataAnnotations;

namespace TecRad.Models.Author
{
	public class AuthorInputModel : HyperMediaModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[Url]
		public string ProfileImgSource { get; set; }

		[MaxLength(255)]
		public string Bio { get; set; }
	}
}