using System.Collections;
using BookCat.Menu;
using BookCat.Storage;

namespace BookCat
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BookLibrary lib = new BookLibrary();
            ArrayList options = new ArrayList(new ISection[] 
                {
                    new AddBook(lib), 
                    new FindName(lib), 
                    new FindAuthor(lib), 
                    new FindISBN(lib), 
                    new FindKeyword(lib)}
                );
            new Start(lib, options).Exec();
        }
    }
}