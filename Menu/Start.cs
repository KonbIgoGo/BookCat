using System;
using System.Collections;
using BookCat.Storage;

namespace BookCat.Menu
{
    public class Start(BookLibrary lib, ArrayList options) : AbstractSection(lib,
        "Добро пожаловать в каталог книг! Выберите действие, введя номер соответствующего пункта:", "")
    {
        public override void Exec()
        {   
            while (true)
            {
                DoGreetings();
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine($"{i+1}.    {((ISection)options[i]).GetDescription()}");
                }

                Console.WriteLine($"{options.Count + 1}.    Выйти\n");
                
                string line;
                start:
                line = Console.ReadLine();
                if (line == null)
                {
                    continue;
                }
                line = line.Trim();
                foreach (char c in line)
                {
                    if (!Char.IsDigit(c))
                    {
                        Console.WriteLine("INCORRECT ARGUMENTS TRY AGAIN\n");
                        goto start;
                    }
                }

                int id = Int32.Parse(line);
                if (id > options.Count+1 || id < 0)
                {
                    Console.WriteLine("INCORRECT ARGUMENTS TRY AGAIN\n");
                    continue;
                }

                if (id == options.Count+1)
                {
                    Console.WriteLine("Выход из программы. До свидания!\n");
                    break;
                }

                ((ISection)options[id - 1]).Exec();   
                

            }
        }
    }
}