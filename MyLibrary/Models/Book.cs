using System.Text.Json.Serialization;

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
        public string Category { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public bool ReadingStatus { get; set; }
        [JsonIgnore]
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }

        

    }
}
