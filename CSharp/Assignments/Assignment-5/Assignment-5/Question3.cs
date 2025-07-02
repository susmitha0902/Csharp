/* 3. Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. 
Create an Indexer of Books Object to store 5 books in a class called BookShelf. Using the indexer method assign values to the books and display the same.
Hint(use Aggregation/composition)*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Question3
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("Ramayana", "Valmiki");
            shelf[1] = new Books("To Kill a Mockingbird", "Harper Lee");
            shelf[2] = new Books("1984", "George Orwell");
            shelf[3] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[4] = new Books("Mahabharata", "Veda Vyasa");
            shelf.DisplayAll();
            Console.ReadLine();
        }
    }
    public class Books
    {
        public string BookName, AuthorName;
        public Books(string BookName, string AuthorName)
        {
            this.BookName = BookName;
            this.AuthorName = AuthorName;
        }
        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }
    public class BookShelf
    {
        private Books[] books = new Books[5];  
        public Books this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine("Books in the Shelf:");
            for (int i = 0; i < books.Length; i++)
            { 
                    Console.Write($"Slot {i + 1}: ");
                    books[i].Display();
            }
        }
    }
}
