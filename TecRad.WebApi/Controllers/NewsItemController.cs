using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Primitives;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using TecRad.Models.NewsItem;


namespace TecRad.WebApi.Controllers
{
	[Route("/api/")]
	public class NewsItemController : Controller
	{
		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("")]
		public IActionResult GetAllNewsItems(int pageSize = 25, int pageNumber = 1)
		{
			return Ok();
		}

		[HttpGet]
		[Route("{newsItemId:int}")]
		public IActionResult GetNewsItemById(int newsItemId)
		{
			return Ok();
		}

		/** ------------- AUTHORIZED ------------- */

		[HttpPost]
		[Route("")]
		public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel newsItem)
		{
			return Ok(newsItem);
		}

		[HttpPut]
		[Route("{newsItemId:int}")]
		public IActionResult UpdateNewsItemById([FromBody] NewsItemInputModel newsItem, int newsItemId)
		{
			return NoContent();
		}

		[HttpDelete]
		[Route("{newsItemId:int}")]
		public IActionResult DeleteNewsItemById(int newsItemId)
		{
			return NoContent();
		}
	}
}