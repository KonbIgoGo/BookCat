using System;
using System.Collections.Generic;
using BookCat.Storage;

namespace BookCat.Util;

// Find support structure.
// Contains book and tokens(optional) that the book was found with
public struct FindSup(Book item, HashSet<string> tokens = null)
{
    private Book item_ = item;
    private HashSet<string> tokens_ = tokens;
    public Book GetItem()
    {
        return item_;
    }
    
    public HashSet<string> GetTokens()
    {
        return tokens_;
    }
}