using Library.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class SearchHelper
    {
        public static void Start(BookLibrary bookLibrary)
        {
            var books = bookLibrary.Books;
            DisplaySearchResults(Search(books));
            return;
        }

        public static IEnumerable<Book> Search(IEnumerable<Book> books)
        {
            Console.WriteLine("What category do you want to search in?");
            var selection = GetSearchModeSelection();
            Console.Write("Enter your query: ");
            var query = Console.ReadLine();
            var result = new List<Book>();
            if (query != null)
            {
                switch (selection)
                {
                    case "T":
                        result = SearchByTitle(query, books).ToList();
                        break;
                    case "A":
                        result = SearchByAuthor(query, books).ToList();
                        break;
                    case "K":
                        result = SearchByKeyword(query, books).ToList();
                        break;
                    case "G":
                        result = SearchByGenre(query, books).ToList();
                        break;
                    case "D":
                        result = SearchByDescription(query, books).ToList();
                        break;
                }
            }
            if (!result.Any())
            {
                Console.WriteLine("No results found!");
            }
            return result;
        }

        public static void DisplaySearchResults(IEnumerable<Book> results)
        {
            Console.WriteLine("Results:");
            for (int i = 0; i < results.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {results.ElementAt(i).Title}");
            }
        }

        private static string GetSearchModeSelection()
        {
            while (true)
            {
                Console.WriteLine(Menu.Dash);
                Console.WriteLine("1 - Title [T]");
                Console.WriteLine("2 - Author [A]");
                Console.WriteLine("3 - Keywords [K]");
                Console.WriteLine("4 - Genre [G]");
                Console.WriteLine("5 - Description [D]");
                Console.WriteLine(Menu.Dash);

                Console.Write("Pick menu item: ");

                var input = Console.ReadLine();

                if (input != null && IsSearchModeSelectionValid(input))
                {
                    return input.ToUpper();
                }
            }
        }

        private static bool IsSearchModeSelectionValid(string userInput)
        {
            var validMenuSelection = new string[] { "T", "A", "K", "G", "D" };

            return validMenuSelection.Contains(userInput.ToUpper());
        }

        private static IEnumerable<Book> SearchByTitle(string query, IEnumerable<Book> books)
        {
            return books.Where(b => b.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IEnumerable<Book> SearchByAuthor(string query, IEnumerable<Book> books)
        {
            books =
                from b in books
                from a in b.Authors
                where a.NickName != null && a.NickName.Contains(query, StringComparison.InvariantCultureIgnoreCase) || 
                a.Name != null && a.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase) || 
                a.Surname != null && a.Surname.Contains(query, StringComparison.InvariantCultureIgnoreCase)
                select b;
            books = books.Distinct<Book>();
            return books;
        }
        
        private static IEnumerable<Book> SearchByKeyword(string query, IEnumerable<Book> books)
        {
            return books.Where(b => b.Keywords.Any(x => x.Contains(query, StringComparison.InvariantCultureIgnoreCase)));
        }

        private static IEnumerable<Book> SearchByGenre(string query, IEnumerable<Book> books)
        {
            return books.Where(b => b.Genre.ToString().Contains(query, StringComparison.InvariantCultureIgnoreCase));
        }

        private static IEnumerable<Book> SearchByDescription(string query, IEnumerable<Book> books)
        {
            return books.Where(b => b.Description.Contains(query, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
