using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Author;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/authors")]
	public class AuthorController : Controller
	{

		[HttpGet]
		[Route("/authors")]
		public IActionResult GetAllAuthors()
		{
			return Ok();
		}

		[HttpGet]
		[Route("{authorId:int")]
		public IActionResult GetAuthorById(int authorId)
		{
			return Ok();
		}

		[HttpGet]
		[Route("authorId:int/newsItems")]
		public IActionResult GetNewsItemsForAuthor(int authorId)
		{
			return Ok();
		}

		/** ------------- AUTHORIZED ------------- */


		[HttpPost]
		[Route("")]
		public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
		{
			return Ok(author);
		}

		[HttpPut]
		[Route("{authorId:int}")]
		public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int authorId)
		{
			return NoContent();
		}

		[HttpDelete]
		[Route("{authorId:int")]
		public IActionResult DeleteAuthorById(int authorId)
		{
			return NoContent();
		}
	}


}