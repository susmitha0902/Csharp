//1.Create a class called Books with BookName and AuthorName as members. Instantiate the class through constructor and also write a method Display() to display the details. 

//Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.

//Hint(use Aggregation/composition)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Question1
    {
        static void Main()
        {
            BookShelf shelf = new BookShelf();

            // Adding books using indexer
            shelf[0] = new Books("The Alchemist", "Paulo Coelho");
            shelf[1] = new Books("Pride and Prejudice", "Jane Austen");
            shelf[2] = new Books("Atomic Habits", "James Clear");
            shelf[3] = new Books("The Hobbit", "J.R.R. Tolkien");
            shelf[4] = new Books("Rich Dad Poor Dad", "Robert T.Kiyosaki");

            // Display all books
            shelf.DisplayBooks();

            Console.ReadLine();
        }
    }
    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book: {BookName}, Author: {AuthorName}");
        }
    }
    public class BookShelf
    {
        private Books[] books = new Books[5];

        // Indexer implementation
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
        public void DisplayBooks()
        {
            Console.WriteLine("Books in the Shelf:");
            for (int i = 0; i < books.Length; i++)
            {
                Console.Write($"Shelf {i + 1}: ");
                books[i].Display();
            }
        }
    }
}
