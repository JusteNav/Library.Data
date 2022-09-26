using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class RemoveBookUIHelper
    {
        internal static void Start(BookLibrary bookLibrary) 
        {
            var books = bookLibrary.Books;
            var choice = GetRemoveModeSelection();
            switch (choice)
            {
                case "L":
                    SearchHelper.DisplaySearchResults(books);
                    var selection = GetBookNumberSelection();
                    if (selection <= books.Count() && GetDeleteConfirmation(books.ElementAt(selection - 1)))
                    {
                        bookLibrary.Remove(books.ElementAt(selection - 1));
                        Console.WriteLine("Your book was removed successfully!");
                    }
                    break;
                case "S":
                    while (true)
                    {
                        var searchResults = SearchHelper.Search(books);
                        SearchHelper.DisplaySearchResults(searchResults);
                        if (searchResults.Count() == 1 && GetDeleteConfirmation(searchResults.First()))
                        {
                            books.Remove(searchResults.First());
                            Console.WriteLine("Your book was removed successfully!");
                            break;
                        }
                    }
                    break;
            }
        }

        private static string GetRemoveModeSelection()
        {
            while (true)
            {
                Console.WriteLine(Menu.Dash);
                Console.WriteLine("1. Pick a book to remove from a List [L]");
                Console.WriteLine("2. Search for a book to remove [S]");
                Console.WriteLine(Menu.Dash);

                Console.Write("Pick menu item: ");

                var input = Console.ReadLine();

                if (input!= null && IsRemoveModeSelectionValid(input))
                {
                    return input.ToUpper();
                }
            }
        }

        private static bool IsRemoveModeSelectionValid(string userInput)
        {
            var validMenuSelection = new string[] { "L", "S" };

            return validMenuSelection.Contains(userInput.ToUpper());
        }

        private static int GetBookNumberSelection()
        {
            while (true)
            {
                Console.Write("Enter a number of the book you want to delete: ");
                var input = Console.ReadLine();
                if(int.TryParse(input, out int result))
                {
                    return result;
                }
            }
        }

        private static bool GetDeleteConfirmation(Book book)
        {
            while (true)
            {
                Console.WriteLine($"Are you sure you want to delete {book.Title} [Y/N]?");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        break;
                }
            }
        }
    }
}
