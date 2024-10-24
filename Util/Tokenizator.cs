using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookCat.Util;

public static class Tokenizator
{
    // splits string on separate words and save every unique word in HashSet
    public static void Tokenize(HashSet<string> set, string text)
    {   
        StringBuilder sb = new StringBuilder();
        foreach (char c in text)
        {
            if (Char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
            else
            {
                if (sb.Length != 0)
                {   
                    set.Add(sb.ToString().ToLowerInvariant());
                    sb.Clear();
                }   
            }
        }

        if (sb.Length != 0)
        {
            set.Add(sb.ToString().ToLowerInvariant());
        }
    }
}