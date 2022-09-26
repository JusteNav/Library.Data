using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class BookLibrary
    {
        public BookLibrary()
        {
            Load();
        }

        private List<Book> _books = new List<Book>();
        
        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Remove(Book book)
        {
            _books.Remove(book);
        }

        public IEnumerable<Book> Search(string query)
        {
            return _books.Where(b => b.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase));
        }

        private void Load()
        {
            _books.Add(new Book("Test title")
            {
                Description = "Descriptiopn",
                Rating = 3,
                Genre = GenreEnum.ScienceFiction,
                Authors = new List<Author>() { new Author("Nick") }.ToArray(),
                Keywords = new string[] { "Old", "England" }
            });

            _books.Add(new Book("Horror one")
            {
                Description = "Some description",
                Rating = 5,
                Genre = GenreEnum.Horror,
                Authors = new List<Author>() { new Author("Nick") }.ToArray(),
                Keywords = new string[] { "Old", "England" }
            });
        }
    }
}
