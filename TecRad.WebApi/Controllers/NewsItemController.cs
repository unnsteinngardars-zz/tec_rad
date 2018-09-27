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

			_newsItemService.GetAllNewsItems().ToList().ForEach(n =>
			{
				n.Links.AddReference("rel", "self");
				n.Links.AddReference("href", $"http://localhost:5000/api/{n.Id}");
				n.Links.AddReference("update", $"http://localhost:5000/api/{n.Id}");
				n.Links.AddReference("delete", $"http://localhost:5000/api/{n.Id}");

				tempList.Add(n);
			});

			var envelope = new Envelope<NewsItemDTO>(pageSize, pageNumber);
			envelope.Items = tempList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			envelope.MaxPages = (int)Math.Ceiling(tempList.Count() / (decimal)pageSize);
			return Ok(envelope);
		}

		[HttpGet]
		[Route("{newsItemId:int}")]
		public IActionResult GetNewsItemById(int newsItemId)
		{
			var newsItem = _newsItemService.GetNewsItemById(newsItemId);
			newsItem.Links.AddReference("rel", "self");
			newsItem.Links.AddReference("href", $"http://localhost:5000/api/{newsItem.Id}");
			newsItem.Links.AddReference("update", $"http://localhost:5000/api/{newsItem.Id}");
			newsItem.Links.AddReference("delete", $"http://localhost:5000/api/{newsItem.Id}");
			return Ok(newsItem);
		}

		/** ------------- AUTHORIZED ------------- */

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel newsItem)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("News item was not properly formatted"); }
			return Ok(_newsItemService.CreateNewNewsItem(newsItem));
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