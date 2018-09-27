using System.Collections.Generic;
using TecRad.Models.Category;
using TecRad.Repositories.Interfaces;
using TecRad.Services.Interfaces;
using AutoMapper;
using TecRad.Models.Exceptions;

namespace TecRad.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repo;
		private readonly INewsItemService _newsItemService;
		public CategoryService(ICategoryRepository repo, INewsItemService newsItemService)
		{
			_repo = repo;
			_newsItemService = newsItemService;
		}
		public int CreateNewCategory(CategoryInputModel category)
		{
			return _repo.CreateNewCategory(category);
		}

		public void DeleteCategoryById(int categoryId)
		{
			var category = _repo.GetCategoryById(categoryId);
			if (category == null) { throw new ResourceNotFoundException($"Category with id: {categoryId} was not found"); }

			_repo.DeleteCategory(category);
		}

		public IEnumerable<CategoryDTO> GetAllCategories()
		{
			return Mapper.Map<IEnumerable<CategoryDTO>>(_repo.GetAllCategories());
		}

		public CategoryDetailDTO GetCategoryById(int categoryId)
		{
			var category = _repo.GetCategoryById(categoryId);
			if (category == null) { throw new ResourceNotFoundException($"Category with id: {categoryId} was not found"); }
			var categoryDetails = Mapper.Map<CategoryDetailDTO>(category);
			categoryDetails.NumberOfNewsItems = _newsItemService.GetNewsItemCountByCategoryId(categoryId);
			return categoryDetails;
		}

		public void LinkNewsItemToCategory(int categoryId, int newsItemId)
		{
			var category = _repo.GetCategoryById(categoryId);
			var newsItem = _newsItemService.GetNewsItemById(newsItemId);
			if (category == null || newsItem == null) { throw new ResourceNotFoundException($"Category with id: {categoryId} was not found"); }
			_repo.LinkNewsItemToCategory(categoryId, newsItemId);
		}

		public void UpdateCategoryById(CategoryInputModel category, int categoryId)
		{
			var validCategory = _repo.GetCategoryById(categoryId);
			if (validCategory == null) { throw new ResourceNotFoundException($"Category with id: {categoryId} was not found"); }

			_repo.UpdateCategoryById(category, categoryId);
		}
	}
}