using BookCat.Storage;
using System.Collections.Generic;
using BookCat.Util;

namespace BookCat.Menu;

public interface IFinder : ISection
{
    List<FindSup> Find(string par);
}