using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace BookCat.Storage
{
    public class BookLibrary
    {
        private const string SaveFile = "books.json";
        private readonly List<Book> _books = [];

        public BookLibrary()
        {   
            var read = StorageReader<List<Book>>.GetDataFromJson(SaveFile);
            if (read != null)
            {
                _books = read;
            }
        }

    public void AddBook(Book item)
        {
            _books.Add(item);
            File.WriteAllText(SaveFile, JsonSerializer.Serialize(_books));
        }

    
        // get list of all books in the library as readonly
        public ReadOnlyCollection<Book> GetLib()
        {
            return _books.AsReadOnly();
        }
    }
}