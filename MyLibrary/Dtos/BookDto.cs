namespace MyLibrary.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberISBN { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public bool ReadingStatus { get; set; }
    }
}
