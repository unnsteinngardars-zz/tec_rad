using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthorById(int authorId);
        IEnumerable<NewsItem> GetNewsItemsForAuthor(int authorId);
        int CreateNewAuthor(AuthorInputModel author);
        void UpdateAuthorById(AuthorInputModel author, int authorId);
        void DeleteAuthor(Author author);
        void LinkAuthorToNewsItem(int authorId, int newsItemId);
    }
}