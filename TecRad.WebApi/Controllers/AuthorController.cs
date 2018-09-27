using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Attributes;
using TecRad.Models.Author;
using TecRad.Models.Exceptions;
using TecRad.Services;
using TecRad.Services.Interfaces;
using System.Linq;
using TecRad.WebApi.Extensions;
using TecRad.Models.NewsItem;
using Newtonsoft.Json.Linq;

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
			JObject self = new JObject();
			JObject newsItems = new JObject();
			JArray newsItemsDetailed = new JArray();
			_authorService.GetAllAuthors().ToList().ForEach(a =>
			{
				self["href"] = $"http://localhost:5000/api/authors/{a.Id}";
				newsItems["href"] = $"http://localhost:5000/api/authors/{a.Id}/newsItems";
				a.Links.AddReference("self", self);
				a.Links.AddReference("edit", self);
				a.Links.AddReference("delete", self);
				a.Links.AddReference("newsItems", newsItems);
				_authorService.GetNewsItemsForAuthor(a.Id).ToList().ForEach(n =>
				{
					JObject detailed = new JObject();
					detailed["href"] = $"http://localhost:5000/api/{n.Id}";
					newsItemsDetailed.Add(detailed);
				});
				a.Links.AddReference("newsItemDetailed", newsItemsDetailed);
				tempList.Add(a);
			});
			return Ok(tempList);
		}

		[HttpGet]
		[Route("{authorId:int}", Name = "GetAuthorById")]
		public IActionResult GetAuthorById(int authorId)
		{
			var author = _authorService.GetAuthorById(authorId);
			JObject self = new JObject();
			JObject newsItems = new JObject();
			JArray newsItemsDetailed = new JArray();
			self["href"] = $"http://localhost:5000/api/authors/{author.Id}";
			newsItems["href"] = $"http://localhost:5000/api/authors/{author.Id}/newsItems";
			author.Links.AddReference("self", self);
			author.Links.AddReference("edit", self);
			author.Links.AddReference("delete", self);
			author.Links.AddReference("newsItems", newsItems);
			_authorService.GetNewsItemsForAuthor(author.Id).ToList().ForEach(n =>
			{
				JObject detailed = new JObject();
				detailed["href"] = $"http://localhost:5000/api/{n.Id}";
				newsItemsDetailed.Add(detailed);
			});
			author.Links.AddReference("newsItemDetailed", newsItemsDetailed);
			return Ok(author);
		}

		[HttpGet]
		[Route("{authorId:int}/newsItems")]
		public IActionResult GetNewsItemsForAuthor(int authorId)
		{
			List<NewsItemDTO> tempList = new List<NewsItemDTO>();
			JObject self = new JObject();
			JObject author = new JObject();
			JObject category = new JObject();
			_authorService.GetNewsItemsForAuthor(authorId).ToList().ForEach(n =>
			{
				self["href"] = $"http://localhost:5000/api/{n.Id}";
				author["href"] = $"http://localhost:5000/api/authors/{n.AuthorId}";
				category["href"] = $"http://localhost:5000/api/categories/{n.CategoryId}";
				n.Links.AddReference("self", self);
				n.Links.AddReference("edit", self);
				n.Links.AddReference("delete", self);
				n.Links.AddReference("author", author);
				n.Links.AddReference("category", category);
				tempList.Add(n);
			});
			return Ok(tempList);
		}

		/** ------------- AUTHORIZED ------------- */

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewAuthor([FromBody] AuthorInputModel author)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
			var id = _authorService.CreateNewAuthor(author);
			return CreatedAtRoute("GetAuthorById", new { authorId = id }, null);
		}

		[Authorize]
		[HttpPut]
		[Route("{authorId:int}")]
		public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int authorId)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("Author was not properly formatted"); }
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