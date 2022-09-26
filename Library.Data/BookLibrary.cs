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

        public List<Book> Books { get { return _books; } } //added get access to book list for searching and removing

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public void Remove(Book book)
        {
            _books.Remove(book);
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
                Authors = new List<Author>() { new Author("Nick"), new Author("John", "Smith") }.ToArray(), //added more than one author for testing purposes
                Keywords = new string[] { "Old", "England" }
            });
        }
    }
}
