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
            XMLBookHelper.Save(_books);
        }

        public void Remove(Book book)
        {
            _books.Remove(book);
        }

        private void Load()
        {
            _books.AddRange(XMLBookHelper.LoadBooks());
        }
    }
}
