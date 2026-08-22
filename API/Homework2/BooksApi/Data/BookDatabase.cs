using BooksApi.Models;

namespace BooksApi.Data
{
    public static class BookDatabase
    {
        public static List<Book> Books = new List<Book>
        {
            new Book() {
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Philosopher's Stone"
            },
            new Book() {
                Author = "J.R.R. Tolkien",
                Title = "The Lord of the Rings"
            },
            new Book() {
                Author = "George Orwell",
                Title = "1984"
            },
            new Book() {
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby"
            },
            new Book() {
                Author = "Gorjan Petrevski",
                Title = "Spomenite za Spomenka"
            }

        };
    }
}
