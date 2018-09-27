using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Primitives;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.NewsItem;
using TecRad.Models;
using TecRad.Services.Interfaces;
using TecRad.Models.Exceptions;
using TecRad.WebApi.Extensions;
using TecRad.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/")]
	public class NewsItemController : Controller
	{
		private readonly INewsItemService _newsItemService;
		public NewsItemController(INewsItemService newsItemService)
		{
			_newsItemService = newsItemService;
		}

		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("")]
		public IActionResult GetAllNewsItems([FromQuery] int pageSize = 25, [FromQuery] int pageNumber = 1)
		{
			List<NewsItemDTO> tempList = new List<NewsItemDTO>();

			JObject self = new JObject();
			JObject author = new JObject();
			JObject category = new JObject();

			_newsItemService.GetAllNewsItems().ToList().ForEach(n =>
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

			var envelope = new Envelope<NewsItemDTO>(pageSize, pageNumber);
			envelope.Items = tempList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			envelope.MaxPages = (int)Math.Ceiling(tempList.Count() / (decimal)pageSize);
			return Ok(envelope);
		}

		[HttpGet]
		[Route("{newsItemId:int}", Name = "GetNewsItemById")]
		public IActionResult GetNewsItemById(int newsItemId)
		{
			var newsItem = _newsItemService.GetNewsItemById(newsItemId);
			JObject self = new JObject();
			JObject author = new JObject();
			JObject category = new JObject();
			self["href"] = $"http://localhost:5000/api/{newsItem.Id}";
			author["href"] = $"http://localhost:5000/api/authors/{newsItem.AuthorId}";
			category["href"] = $"http://localhost:5000/api/categories/{newsItem.CategoryId}";
			newsItem.Links.AddReference("rel", self);
			newsItem.Links.AddReference("href", self);
			newsItem.Links.AddReference("update", self);
			newsItem.Links.AddReference("delete", self);
			newsItem.Links.AddReference("author", author);
			newsItem.Links.AddReference("category", category);
			return Ok(newsItem);
		}

		/** ------------- AUTHORIZED ------------- */

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel newsItem)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("News item was not properly formatted"); }
			var id = _newsItemService.CreateNewNewsItem(newsItem);
			return CreatedAtRoute("GetNewsItemById", new { newsItemId = id }, null);
		}

		[Authorize]
		[HttpPut]
		[Route("{newsItemId:int}")]
		public IActionResult UpdateNewsItemById([FromBody] NewsItemInputModel newsItem, int newsItemId)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("News item was not properly formatted"); }
			_newsItemService.UpdateNewsItemById(newsItem, newsItemId);
			return NoContent();
		}
		[Authorize]
		[HttpDelete]
		[Route("{newsItemId:int}")]
		public IActionResult DeleteNewsItemById(int newsItemId)
		{
			_newsItemService.DeleteNewsItemById(newsItemId);
			return NoContent();
		}
	}
}