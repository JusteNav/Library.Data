using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal static class AddBookUIHelper
    {
        internal static void Start(BookLibrary bookLibrary)
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Description: ");
            var description = Console.ReadLine();

            Console.Write("Genre: ");
            var genre = Console.ReadLine();

            Console.Write("Rating: ");
            var rating = Console.ReadLine();

            var authors = GetAuthors();

            var keywords = GetKeywords();

            var book = new Book(title)
            {
                Description = description,
                Genre = (GenreEnum)Enum.Parse(typeof(GenreEnum), genre),
                Rating = byte.Parse(rating),
                Authors = authors,
                Keywords = keywords
            };

            bookLibrary.Add(book);
        }

        private static string[] GetKeywords()
        {
            var keywords = new List<string>();

            Console.WriteLine("Please add some keywords");
            Console.WriteLine("------------------------");

            while (true)
            {
                Console.Write("Keyword: ");
                var keyword = Console.ReadLine();

                if(!string.IsNullOrEmpty(keyword))
                {
                    keywords.Add(keyword);
                }

                Console.WriteLine("Would you like to add one more keyword [Y/N]?");

                var res = Console.ReadLine();

                if (res.ToUpper() == "N")
                {
                    return keywords.ToArray();
                }
            }
        }
        
        private static Author[] GetAuthors()
        {
            var authors = new List<Author>();

            Console.WriteLine("Please add authors");
            Console.WriteLine("------------------------");

            while (true)
            {
                Console.Write("Name:");
                var name = Console.ReadLine();

                Console.Write("Surname:");
                var surname = Console.ReadLine();

                Console.Write("Nickname:");
                var nickname = Console.ReadLine();

                if(!string.IsNullOrEmpty(name) 
                    || !string.IsNullOrEmpty(surname)
                    || !string.IsNullOrEmpty(nickname))
                {
                    authors.Add(new Author(name, surname, nickname));

                    Console.WriteLine("Would you like to add one more author [Y/N]?");

                    var res = Console.ReadLine();

                    if(res.ToUpper() == "N")
                    {
                        return authors.ToArray();
                    }
                }
            }
        }
    }
}
