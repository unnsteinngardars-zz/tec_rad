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
        private readonly IDataContext _dataContext;

        public NewsItemRepository(IDataContext dataContext){
            _dataContext = dataContext;
        }   
        public IEnumerable<NewsItem> GetAllNewsItems() => 
            _dataContext.getNewsItems;
        
        public NewsItem GetNewsItemById(int newsItemId) => 
            _dataContext.getNewsItems.FirstOrDefault(n => n.Id == newsItemId);

        public int CreateNewNewsItem(NewsItemInputModel newsItem){
            var nextId = _dataContext.getNewsItems.Count() +1 ;
            var entity = Mapper.Map<NewsItem>(newsItem);
            entity.Id = nextId;
            _dataContext.getNewsItems.Add(entity);
            return nextId;
        }

        public void UpdateNewsItemById(NewsItemInputModel newsItem, int newsItemId){
            var updateNewsItem = _dataContext.getNewsItems.FirstOrDefault(n => n.Id == newsItemId);
            updateNewsItem.Title = newsItem.Title;
            updateNewsItem.ImgSource = newsItem.ImgSource;
            updateNewsItem.ShortDescription = newsItem.ShortDescription;
            updateNewsItem.LongDescription = newsItem.LongDescription;
            updateNewsItem.PublishDate = newsItem.PublishDate == null ? DateTime.Now : newsItem.PublishDate;
        }

        public void DeleteNewsItem(NewsItem newsItem){
            _dataContext.getNewsItems.Remove(newsItem);
        }

    
    }
}