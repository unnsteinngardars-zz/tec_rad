using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Attributes;
using TecRad.Models.Category;
using TecRad.Models.Exceptions;
using TecRad.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using TecRad.WebApi.Extensions;
using Newtonsoft.Json.Linq;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/categories/")]
	public class CategoryController : Controller
	{

		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("")]
		public IActionResult GetAllCategories()
		{
			JObject self = new JObject();
			List<CategoryDTO> tempList = new List<CategoryDTO>();
			_categoryService.GetAllCategories().ToList().ForEach(c =>
			{
				self["href"] = $"http:/localhost:5000/api/categories/{c.Id}";
				c.Links.AddReference("rel", self);
				c.Links.AddReference("href", self);
				c.Links.AddReference("update", self);
				c.Links.AddReference("delete", self);
				tempList.Add(c);
			});
			return Ok(tempList);
		}

		[HttpGet]
		[Route("{categoryId:int}", Name = "GetCategoryById")]
		public IActionResult GetCategoryById(int categoryId)
		{
			var category = _categoryService.GetCategoryById(categoryId);
			JObject self = new JObject();
			self["href"] = $"http://localhost:5000/api/categories/{category.Id}";
			category.Links.AddReference("rel", self);
			category.Links.AddReference("href", self);
			category.Links.AddReference("update", self);
			category.Links.AddReference("delete", self);
			return Ok(category);
		}

		/** ------------- AUTHORIZED ------------- */

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			var id = _categoryService.CreateNewCategory(category);
			return CreatedAtRoute("GetCategoryById", new { categoryId = id }, null);
		}

		[Authorize]
		[HttpPut]
		[Route("{categoryId:int}")]
		public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int categoryId)
		{
			if (!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			_categoryService.UpdateCategoryById(category, categoryId);
			return NoContent();
		}

		[Authorize]
		[HttpDelete]
		[Route("{categoryId:int}")]
		public IActionResult DeleteCategoryById(int categoryId)
		{
			_categoryService.DeleteCategoryById(categoryId);
			return NoContent();
		}

		[Authorize]
		[HttpPost]
		[Route("{categoryId:int}/newsItems/{newsItemId:int}")]
		public IActionResult LinkNewsItemToCategory(int categoryId, int newsItemId)
		{
			_categoryService.LinkNewsItemToCategory(categoryId, newsItemId);
			return Ok();
		}

	}
}