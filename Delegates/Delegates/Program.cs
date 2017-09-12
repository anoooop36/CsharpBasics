using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
   

    public struct Book
    {
        public static void Main(string[] args)
        { }
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;

        public Book(string title,string author,decimal price,bool paperback)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperback;
        }
    }

    public delegate void ProcessBookDelegate(Book book);

    //Maintnain a book database.
    public class BookDB
    {
        List<Book> list = new List<Book>();
        public void AddBook(string title,string author,decimal price,bool paperback)
        {
            list.Add(new Book(title,author,price,paperback));
        }

        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (Book b in list)
            {
                if (b.Paperback)
                {
                    processBook(b);
                }
            }
        }
    }

}
