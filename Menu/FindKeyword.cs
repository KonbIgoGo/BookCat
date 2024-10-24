using System;
using System.Collections.Generic;
using BookCat.Storage;
using BookCat.Util;

namespace BookCat.Menu
{
    public class FindKeyword(BookLibrary lib) : AbstractFinder(lib, "Введите ключевые слова: ", "Найти книгу по ключевым словам")
    {
        protected override FindSup FindImpl(Book item, string par)
        {
            HashSet<string> tokens = []; 
            Tokenizator.Tokenize(tokens, par);

            HashSet<string> keywords = [];
            
            foreach (string token in tokens)
            {
                if (item.FindKeywordInAnnotation(token))
                {
                    keywords.Add(token);
                }

                if (item.FindGenres(token))
                {
                    keywords.Add(token);
                }
            }


            return keywords.Count > 0 ? new FindSup(item, keywords) : new FindSup(null);;
        }
    }
}