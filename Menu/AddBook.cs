using System;
using System.Collections.Generic;
using BookCat.Storage;

namespace BookCat.Menu
{
    public class AddBook(BookLibrary lib) : AbstractSection(lib, "Ваш выбор 1:", "Добавить книгу в каталог")
    {
        // Ensures correct input from console and delete unnecessary whitespaces at the start and the end of line
        private static string DataInsurance(string msg, bool isNum = false)
        {
            while (true)
            {
                Console.WriteLine(msg);
                string data = Console.ReadLine();
                
                if (data == null)
                {
                    Console.WriteLine("Введены некорректные данные. Попробуйте снова.");
                    continue;
                }
                data = data.Trim();

                if (data.Equals(""))
                {
                    Console.WriteLine("Введены некорректные данные. Попробуйте снова.");
                    continue;
                }
                
                if (isNum)
                {
                    bool flag = false;
                    foreach (char c in data)
                    {
                        if (!char.IsDigit(c))
                        {
                            Console.WriteLine("Введены некорректные данные. Попробуйте снова.");
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        continue;
                    }
                }

                return data.Trim();
            }
        }
        
        public override void Exec()
        {
            string title = DataInsurance("Введите название книги: ");
            string author = DataInsurance("Введите имя автора: ");
            string genres = DataInsurance("Введите жанры(Через запятую): ");
            string year = DataInsurance("Введите год: ", true);
            string annotation = DataInsurance("Ведите аннотацию: ");
            string isbn = DataInsurance("Введите ISBN: ");

            lib.AddBook(new Book(title, int.Parse(year), author, isbn, annotation, genres));
            Console.WriteLine("Книга успешно добавлена в каталог!\n");
        }
    }
}