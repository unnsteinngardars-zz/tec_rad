using System.Collections.Generic;
using TecRad.Models.NewsItem;

namespace TecRad.Services.Interfaces
{
    public interface INewsItemService
    {
         IEnumerable<NewsItemDTO> GetAllNewsItems();
         NewsItemDTO GetNewsItemById(int newsItemId);
         int CreateNewNewsItem(NewsItemInputModel newsItem);
         void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId);
         void DeleteNewsItemById(int newsItemId);
    }
}