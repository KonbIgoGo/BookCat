using BookCat.Storage;
using BookCat.Util;

namespace BookCat.Menu
{
    public class FindISBN(BookLibrary lib) : AbstractFinder(lib, "Введите номер ISBN книги: ", "Найти книгу по ISBN")
    { 
        protected override FindSup FindImpl(Book item, string par)
        {
            return item.GetIsbn().Equals(par.Trim().ToLowerInvariant()) ? new FindSup(item) : new FindSup(null);
        }
    }
}