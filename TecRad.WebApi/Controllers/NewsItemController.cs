using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Primitives;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.NewsItem;
using TecRad.Services.Interfaces;
using TecRad.Models;
using TecRad.Models.Exceptions;

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
			// TODO:: Link dótið && order descending !

			var envelope = new Envelope<NewsItemDTO>(pageSize, pageNumber);
			var list = _newsItemService.GetAllNewsItems();
			envelope.Items = list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			envelope.MaxPages = (int) Math.Ceiling(list.Count() / (decimal) pageSize);
			return Ok(envelope);
		}

		[HttpGet]
		[Route("{newsItemId:int}")]
		public IActionResult GetNewsItemById(int newsItemId)
		{
			return Ok(_newsItemService.GetNewsItemById(newsItemId));
		}

		/** ------------- AUTHORIZED ------------- */
		// TODO:: AUTHORIZE dis sjit

		[HttpPost]
		[Route("")]
		public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel newsItem)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("News item was not properly formatted"); }
			return Ok(_newsItemService.CreateNewNewsItem(newsItem));
		}

		[HttpPut]
		[Route("{newsItemId:int}")]
		public IActionResult UpdateNewsItemById([FromBody] NewsItemInputModel newsItem, int newsItemId)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("News item was not properly formatted"); }
			_newsItemService.UpdateNewsItemById(newsItem, newsItemId);
			return NoContent();
		}

		[HttpDelete]
		[Route("{newsItemId:int}")]
		public IActionResult DeleteNewsItemById(int newsItemId)
		{
			_newsItemService.DeleteNewsItemById(newsItemId);
			return NoContent();
		}
	}
}