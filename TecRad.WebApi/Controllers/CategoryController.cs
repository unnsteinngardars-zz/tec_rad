using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Attributes;
using TecRad.Models.Category;
using TecRad.Models.Exceptions;
using TecRad.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using TecRad.WebApi.Extensions;

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
			List<CategoryDTO> tempList = new List<CategoryDTO>();
			_categoryService.GetAllCategories().ToList().ForEach(c => {
				c.Links.AddReference("rel", "self");
				c.Links.AddReference("href", $"http://localhost:5000/api/categories/{c.Id}");
				c.Links.AddReference("update", $"http://localhost:5000/api/categories/{c.Id}");
				c.Links.AddReference("delete", $"http://localhost:5000/api/categories/{c.Id}");
				tempList.Add(c);
			});
			return Ok(tempList);
		}

		[HttpGet]
		[Route("{categoryId:int}")]
		public IActionResult GetCategoryById(int categoryId)
		{
			var category = _categoryService.GetCategoryById(categoryId);
			category.Links.AddReference("rel", "self");
			category.Links.AddReference("href", $"http://localhost:5000/api/categories/{category.Id}");
			category.Links.AddReference("update", $"http://localhost:5000/api/categories/{category.Id}");
			category.Links.AddReference("delete", $"http://localhost:5000/api/categories/{category.Id}");
			return Ok(category);
		}

		/** ------------- AUTHORIZED ------------- */

		[Authorize]
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			return Ok(_categoryService.CreateNewCategory(category));
		}

		[Authorize]
		[HttpPut]
		[Route("{categoryId:int}")]
		public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int categoryId)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			_categoryService.UpdateCategoryById(category, categoryId);
			return NoContent();
		}

		[Authorize]
		[HttpDelete]
		[Route("{categoryId:int}")]
		public IActionResult DeleteCategoryById(int categoryId)
		{	_categoryService.DeleteCategoryById(categoryId);
			return NoContent();
		}

		[Authorize]
		[HttpPost]
		[Route("{categoryId:int}/newsItems/{newsItemId:int}")]
		public IActionResult LinkNewsItemToCategory(int categoryId, int newsItemId){
			_categoryService.LinkNewsItemToCategory(categoryId, newsItemId);
			return Ok();
		}

	}
}