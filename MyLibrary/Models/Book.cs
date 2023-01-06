namespace MyLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Language { get; set; }
        //the language of this book in the library 
        public string Category { get; set; }
        public string Format { get; set; }
        // format(paperbag, e-book, audiobook)
        public string Description { get; set; }
        public bool ReadingStatus { get; set; }
        // or public string ReadingStatus { get; set; } - read, not read, while reading

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

    }
}
