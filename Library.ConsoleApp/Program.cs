using Library.Data;

namespace Library.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookLibrary = new BookLibrary();

            while(true)
            {
                var menuSelection = Menu.GetUserMenuSelection();

                switch (menuSelection)
                {
                    case "A":
                        AddBookUIHelper.Start(bookLibrary);
                        break;
                    case "R":
                        break;
                    case "S":
                        break;
                    case "E":
                        return;
                }
            }
        }
    }
}