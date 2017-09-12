using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace BookTestClient
{
    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    class Test
    {
        static void PrintTitle(Book b)
        {
            Console.WriteLine("     {0}",b.Title);
        }

        public static void Main(string[] args)
        {
            BookDB bookDB = new BookDB();
            AddBooks(bookDB);
            Console.WriteLine("PaperBack Book Titles:");
            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));
            PriceTotaller totaller = new PriceTotaller();
            bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}",totaller.AveragePrice());
            Console.ReadKey();
        }

        //Initalize the book databases with some test books:
        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("Programming in C ", "Dennis Retchie",19.95m,true);
            bookDB.AddBook("Database Design", "Korth", 50.0m, true);
            bookDB.AddBook("Compiler Design","Aho Ulman Lam Sethi",33.0m,false);
        }

    }
}
