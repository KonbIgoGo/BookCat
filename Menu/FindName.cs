using System.Collections.Generic;
using BookCat.Storage;
using BookCat.Util;

namespace BookCat.Menu
{
    public class FindName(BookLibrary lib) : AbstractFinder(lib, "Введите полное или частичное название книги: ", "Найти книгу по названию")
    {
        protected override FindSup FindImpl(Book item, string par)
        {
            HashSet<string> tokens = []; 
            Tokenizator.Tokenize(tokens, par);

            List<string> keywords = [];
            
            foreach (string token in tokens)
            {
                if (item.FindTitle(token))
                {
                    keywords.Add(token);   
                }
            }

            return keywords.Count > 0 ? new FindSup(item) : new FindSup(null);
        }
    }
}