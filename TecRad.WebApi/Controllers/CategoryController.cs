using Microsoft.AspNetCore.Mvc;
using TecRad.Models.Category;

namespace TecRad.WebApi.Controllers
{
	[Route("/api/categories")]
	public class CategoryController : Controller
	{

		/** ------------- UNAUTHORIZED ------------- */

		[HttpGet]
		[Route("")]
		public IActionResult GetAllCategories()
		{
			return Ok();
		}

		[HttpGet]
		[Route("{categoryId:int}")]
		public IActionResult GetCategoryById(int categoryId)
		{
			return Ok();
		}

		/** ------------- AUTHORIZED ------------- */

		[HttpPost]
		[Route("")]
		public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
		{
			return Ok(category);
		}

		[HttpPut]
		[Route("{categoryId:int}")]
		public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int categoryId)
		{
			return NoContent();
		}

		[HttpDelete]
		[Route("{categoryId:int")]
		public IActionResult DeleteCategoryById(int categoryId)
		{
			return NoContent();
		}

		[HttpPost]
		[Route("{categoryId:int}/newsItems/{newsItemId:int}")]
		public IActionResult LinkNewsItemToCategory(int categoryId, int newsItemId){
			return Ok();
		}

	}
}