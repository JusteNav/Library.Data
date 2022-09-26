namespace Library.Data
{
    public class Book
    {
        public Book(string title)
        {
            Title = title;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public Author[] Authors { get; set; }

        public GenreEnum Genre { get; set; }

        public string[] Keywords { get; set; }

        public byte Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}\n{Description}";
        }

    }
}