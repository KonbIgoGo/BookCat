using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BookCat.Storage;
using BookCat.Util;

namespace BookCat.Menu;

public abstract class AbstractFinder(BookLibrary lib, string msg, string description) : AbstractSection(lib, msg, description), IFinder
{
    private ReadOnlyCollection<Book> GetLib()
    {
        return Lib.GetLib();
    }

    protected abstract FindSup FindImpl(Book item, string par);

    public List<FindSup> Find(string par)
    {
        List<FindSup> res = [];
        foreach (Book i in GetLib())
        {
            FindSup it = FindImpl(i, par);
            if (it.GetItem() != null) 
            {
                res.Add(it);
            }
        }

        return res;
    }

    public override void Exec()
    {   
        DoGreetings();
        while (true)
        {  
            string line = Console.ReadLine();
            if (line == null)
            {
                continue;
            }

            List<FindSup> res = Find(line.Trim());
            
            
            if (res.Count == 0)
            {
                Console.WriteLine("Не удалось найти книг по заданным параметрам.\n");
                break;
            }

            if (res.First().GetTokens() != null)
            {
                // sort by found tokens amount
                res.Sort((x, y) => -x.GetTokens().Count.CompareTo(y.GetTokens().Count));   
            }
            
            foreach (var i in res)
            {
                Console.WriteLine(i.GetItem().GetBriefInfo());

                if (i.GetTokens() != null)
                {
                    
                    StringBuilder sb = new StringBuilder();
                
                    foreach (var token in i.GetTokens())
                    {
                        if (sb.Length == 0)
                        {
                            sb.Append(token);
                        }
                        else
                        {
                            sb.Append($", {token}");
                        }
                    }
                    Console.WriteLine($"Найденные ключевые слова: {sb.ToString().Replace("[", "").Replace("]", "")}\n");
                }
                
                
            }
            break;
        }
    }
}