using System.Collections.Generic;
using TecRad.Models.Exceptions;
using TecRad.Models.NewsItem;
using TecRad.Repositories.Interfaces;
using TecRad.Services.Interfaces;
using AutoMapper;
using System.Linq;


namespace TecRad.Services
{
	public class NewsItemService : INewsItemService
	{
		private readonly INewsItemRepository _repo;

		public NewsItemService(INewsItemRepository repo)
		{
			_repo = repo;
		}

		public int CreateNewNewsItem(NewsItemInputModel newsItem)
		{
			return _repo.CreateNewNewsItem(newsItem);
		}
		public void DeleteNewsItemById(int newsItemId)
		{
			var newsItem = _repo.GetNewsItemById(newsItemId);
			if (newsItem == null) { throw new ResourceNotFoundException($"News item with id {newsItemId} was not found."); }
			_repo.DeleteNewsItem(newsItem);
		}

		public IEnumerable<NewsItemDTO> GetAllNewsItems()
		{
			return Mapper.Map<IEnumerable<NewsItemDTO>>(_repo.GetAllNewsItems());
		}

		public NewsItemDetailDTO GetNewsItemById(int newsItemId)
		{
			var newsItem = _repo.GetNewsItemById(newsItemId);
			if (newsItem == null) { throw new ResourceNotFoundException($"News item with id {newsItemId} was not found."); }

			return Mapper.Map<NewsItemDetailDTO>(newsItem);
		}

		public void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId)
		{
			var validNewsItem = _repo.GetNewsItemById(newsItemId);
			if (validNewsItem == null) { throw new ResourceNotFoundException($"News item with id {newsItemId} was not found."); }

			_repo.UpdateNewsItemById(newsItem, newsItemId);
		}

		public int GetNewsItemCountByCategoryId(int categoryId)
		{
			return _repo.GetAllNewsItems().Where(n => n.CategoryId == categoryId).Count();
		}
	}
}