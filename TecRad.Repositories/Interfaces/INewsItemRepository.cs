using System.Collections.Generic;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Interfaces
{
    public interface INewsItemRepository
    {
         IEnumerable<NewsItem> GetAllNewsItems();
         NewsItem GetNewsItemById(int newsItemId);
         int CreateNewNewsItem(NewsItemInputModel newsItem);
         void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId);
         void DeleteNewsItem(NewsItem newsItem);

    }
}