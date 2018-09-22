using System.Collections.Generic;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Interfaces
{
    public interface INewsItemRepository
    {
         IEnumerable<NewsItemDTO> GetAllNewsItems();
         NewsItemDTO GetNewsItemById(int newsItemId);
         int CreateNewNewsItem(NewsItemInputModel newsItem);
         void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId);
         void DeleteNewsItem(NewsItemDTO newsItem);

    }
}