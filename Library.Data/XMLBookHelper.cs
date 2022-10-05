using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Data
{
    internal class XMLBookHelper
    {
        private readonly static string _filePath = @"../../../../Library.Data/Books.xml";
        private readonly static string _rootAttribute = "Books";

        internal static List<Book> LoadBooks()
        {
            var deserializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute(_rootAttribute));

            using (var reader = new StreamReader(_filePath))
            {
                var book = deserializer.Deserialize(reader);
                return (List<Book>)book;
            }
        }

        internal static void Save(List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute(_rootAttribute));
            using (var writer = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(writer, books);
            }
        }
    }
}
