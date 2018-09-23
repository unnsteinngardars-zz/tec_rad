using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Category;
using TecRad.Models.Exceptions;
using TecRad.Services.Interfaces;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/categories")]
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
			return Ok(_categoryService.GetAllCategories());
		}

		[HttpGet]
		[Route("{categoryId:int}")]
		public IActionResult GetCategoryById(int categoryId)
		{
			return Ok(_categoryService.GetCategoryById(categoryId));
		}

		/** ------------- AUTHORIZED ------------- */
		// TODO:: AUTHORIZE dis sjit
		
		[HttpPost]
		[Route("")]
		public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			return Ok(_categoryService.CreateNewCategory(category));
		}

		[HttpPut]
		[Route("{categoryId:int}")]
		public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int categoryId)
		{
			if(!ModelState.IsValid) { throw new ModelFormatException("Category was not properly formatted"); }
			_categoryService.UpdateCategoryById(category, categoryId);
			return NoContent();
		}

		[HttpDelete]
		[Route("{categoryId:int}")]
		public IActionResult DeleteCategoryById(int categoryId)
		{	_categoryService.DeleteCategoryById(categoryId);
			return NoContent();
		}

		[HttpPost]
		[Route("{categoryId:int}/newsItems/{newsItemId:int}")]
		public IActionResult LinkNewsItemToCategory(int categoryId, int newsItemId){
			_categoryService.LinkNewsItemToCategory(categoryId, newsItemId);
			return Ok();
		}

	}
}