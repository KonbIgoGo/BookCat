using System;
using BookCat.Storage;

namespace BookCat.Menu
{
    public abstract class AbstractSection(BookLibrary lib, string msg, string description) : ISection
    {
        protected readonly BookLibrary Lib = lib;
        public string GetDescription()
        {
            return description;
        }

        protected void DoGreetings()
        {
            Console.WriteLine(msg);
        }
        
        // execute section implementation
        public abstract void Exec();
    }
}