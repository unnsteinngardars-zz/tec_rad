using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Author;
using TecRad.Models.Exceptions;
using TecRad.Services;
using TecRad.Services.Interfaces;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/authors")]
	public class AuthorController : Controller
	{
		private readonly IAuthorService _authorService;

		public AuthorController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("/authors")]
		public IActionResult GetAllAuthors()
		{
			var authors =_authorService.GetAllAuthors();
			return Ok(authors);
		}

		[HttpGet]
		[Route("{authorId:int}")]
		public IActionResult GetAuthorById(int authorId)
		{
			return Ok(_authorService.GetAuthorById(authorId));
		}

		[HttpGet]
		[Route("{authorId:int}/newsItems")]
		public IActionResult GetNewsItemsForAuthor(int authorId)
		{
			return Ok(_authorService.GetNewsItemsForAuthor(authorId));
		}

		/** ------------- AUTHORIZED ------------- */
		// TODO:: AUTHORIZE dis sjit

		[HttpPost]
		[Route("")]
		public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
			return Ok(_authorService.CreateNewAuthor(author));
		}

		[HttpPut]
		[Route("{authorId:int}")]
		public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int authorId)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
			_authorService.UpdateAuthorById(author, authorId);
			return NoContent();
		}

		[HttpDelete]
		[Route("{authorId:int}")]
		public IActionResult DeleteAuthorById(int authorId)
		{
			_authorService.DeleteAuthorById(authorId);
			return NoContent();
		}

		// TODO : Er POST rétt hér ?
		[HttpPost]
		[Route("{authorId:int}/newsItems/{newsItemId}")]
		public IActionResult LinkAuthorToNewsItem(int authorId, int newsItemId)
		{
			_authorService.LinkAuthorToNewsItem(authorId, newsItemId);
			return Ok();
		}
	}


}