using System;
using System.Text.Json;
using System.IO;

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
            string serializedBook = SerializeToJson("filename.txt", LOTR);
            //deserialize to object
            Book deserializedBook = DeserializeFromJson(serializedBook);

            //output the serialized book information
            string readSerText = File.ReadAllText(serializedBook);
            Console.WriteLine(readSerText);

            //output the deserialized book information
            Console.WriteLine($"Deserialized from Json: {deserializedBook.Title}, {deserializedBook.Author}, {deserializedBook.Year}");

            //wait for user input before closing
            Console.ReadKey();
        }

        //create a method that serializes a book object
        static string SerializeToJson(string fileName, Book book)
        {
            //create file and write the book object to it
            File.WriteAllText(fileName, Convert.ToString(book));

            //serialize object to JSON
            string serialized = JsonSerializer.Serialize<Book>(book);

            //return fileName for the main method
            return serialized;
        }

        //create a method that deserializes a book object
        static Book DeserializeFromJson(string fileName)
        {
            //creat

            //deserialize JSON to object
            Book deserializedBook = JsonSerializer.Deserialize<Book>(fileName);

            //reutrn object to main method
            return deserializedBook;
        }
    }
}
