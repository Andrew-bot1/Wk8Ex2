using System;
using System.Text.Json;

namespace Wk8Ex2
{
    internal class Program
    {
        //create a class for books
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }

        static void Main(string[] args)
        {
            //create a book object
            Book LOTR = new Book () {
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Year = 1954
            };

            //serialize the book object
            string serializedBook = SerializeToJson("JsonBook", LOTR);
            //deserialize to object
            Book deserializedBook = DeserializeFromJson(serializedBook);

            //output serialized and deserialized book information
            Console.WriteLine("Serialized to Json: " + serializedBook);
            Console.WriteLine($"Deserialized from Json: {deserializedBook.Title}, {deserializedBook.Author}, {deserializedBook.Year}");

            //wait for user input before closing
            Console.ReadKey();
        }

        //create a method that serializes a book object
        static string SerializeToJson(string fileName, Book book)
        {
            //serialize object to JSON
            fileName = JsonSerializer.Serialize<Book>(book);

            //return fileName for the main method
            return fileName;
        }

        //create a method that deserializes a book object
        static Book DeserializeFromJson(string fileName)
        {
            //deserialize JSON to object
            Book deserializedBook = JsonSerializer.Deserialize<Book>(fileName);

            //reutrn object to main method
            return deserializedBook;
        }
    }
}
