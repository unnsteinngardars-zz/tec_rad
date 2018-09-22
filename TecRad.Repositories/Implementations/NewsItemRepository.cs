using System.Collections.Generic;
using TecRad.Models.NewsItem;
using TecRad.Repositories.Data;
using TecRad.Repositories.Interfaces;
using AutoMapper;
using System.Linq;
using System;

namespace TecRad.Repositories
{
    public class NewsItemRepository : INewsItemRepository
    {
        
        public IEnumerable<NewsItemDTO> GetAllNewsItems() => 
            Mapper.Map<IEnumerable<NewsItemDTO>>(DataContext._newsItems);
        
        public NewsItemDTO GetNewsItemById(int newsItemId) => 
            Mapper.Map<NewsItemDTO>(DataContext._newsItems.FirstOrDefault(n => n.Id == newsItemId));

        public int CreateNewNewsItem(NewsItemInputModel newsItem){
            var nextId = DataContext._newsItems.Count() +1 ;
            var entity = Mapper.Map<NewsItem>(newsItem);
            entity.Id = nextId;
            DataContext._newsItems.Add(entity);
            return nextId;
        }

        public void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId){
            var updateNewsItem = DataContext._newsItems.FirstOrDefault(n => n.Id == newsItemId);

            if( updateNewsItem == null) return;

            updateNewsItem.Title = newsItem.Title;
            updateNewsItem.ImgSource = newsItem.ImgSource;
            updateNewsItem.ShortDescription = newsItem.ShortDescription;
            updateNewsItem.LongDescription = newsItem.LongDescription;
            // TODO: Athuga hvort maður eigi að setja nýja dagsetningu inní publish date?
            updateNewsItem.PublishDate = newsItem.PublishDate == null ? DateTime.Now : newsItem.PublishDate;
        }

        public void DeleteNewsItem(NewsItemDTO newsItem){
            DataContext._newsItems.Remove(Mapper.Map<NewsItem>(newsItem));
        }

    
    }
}