using BookCat.Storage;
using BookCat.Util;

namespace BookCat.Menu
{
    public class FindAuthor(BookLibrary lib) : AbstractFinder(lib, "Введите имя автора книги: ", "Найти книгу по имени автора")
    {
        protected override FindSup FindImpl(Book item, string par)
        {
            return item.FindAuthor(par) ? new FindSup(item) : new FindSup(null);
        }
    }
}