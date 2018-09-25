using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Attributes;
using TecRad.Models.Author;
using TecRad.Models.Exceptions;
using TecRad.Services;
using TecRad.Services.Interfaces;
using System.Linq;
using TecRad.WebApi.Extensions;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/authors/")]
	public class AuthorController : Controller
	{
		private readonly IAuthorService _authorService;

		public AuthorController(IAuthorService authorService)
		{
			_authorService = authorService;
		}

		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("")]
		public IActionResult GetAllAuthors()
		{
			List<AuthorDTO> tempList = new List<AuthorDTO>();
			_authorService.GetAllAuthors().ToList().ForEach(a => {
				a.Links.AddReference("self", $"http://localhost:5000/api/authors/{a.Id}");
				tempList.Add(a);
			});
			return Ok(tempList);
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

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
			return Ok(_authorService.CreateNewAuthor(author));
		}

		[Authorize]
		[HttpPut]
		[Route("{authorId:int}")]
		public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int authorId)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
			_authorService.UpdateAuthorById(author, authorId);
			return NoContent();
		}

		[Authorize]
		[HttpDelete]
		[Route("{authorId:int}")]
		public IActionResult DeleteAuthorById(int authorId)
		{
			_authorService.DeleteAuthorById(authorId);
			return NoContent();
		}

		[HttpPost]
		[Route("{authorId:int}/newsItems/{newsItemId}")]
		public IActionResult LinkAuthorToNewsItem(int authorId, int newsItemId)
		{
			_authorService.LinkAuthorToNewsItem(authorId, newsItemId);
			return Ok();
		}
	}


}