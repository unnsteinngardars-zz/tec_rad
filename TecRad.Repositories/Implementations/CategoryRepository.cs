using System.Linq;
using TecRad.Models.Category;
using TecRad.Repositories.Data;
using System.Collections.Generic;
using TecRad.Repositories.Interfaces;
using AutoMapper;

namespace TecRad.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataContext _dataContext;

        public CategoryRepository(IDataContext dataContext) {
            _dataContext = dataContext;
        }
        public IEnumerable<Category> GetAllCategories() => 
           _dataContext.getCategories;
            
        public Category GetCategoryById(int categoryId) => 
            _dataContext.getCategories.FirstOrDefault(c => c.Id == categoryId);

        public int CreateNewCategory(CategoryInputModel category){
            var items = _dataContext.getCategories;
            var entity = Mapper.Map<Category>(category);
            entity.Id = items.Count +1;
            items.Add(entity);

            return entity.Id;
        }

        public void UpdateCategoryById(CategoryInputModel category, int categoryId) {
            var updateCategory = _dataContext.getCategories.FirstOrDefault(c => c.Id == categoryId);
            updateCategory.Name = category.Name;
            updateCategory.ParentCategoryId = category.ParentCategoryId;
            updateCategory.Slug = category.Slug;
        }

        public void DeleteCategory(Category category){
            _dataContext.getCategories.Remove(category);
        }

        public void LinkNewsItemToCategory(int categoryId, int newsItemId){
            var newsItem = _dataContext.getNewsItems.FirstOrDefault(n => n.Id == newsItemId);
            newsItem.CategoryId = categoryId;
        }
    }
}