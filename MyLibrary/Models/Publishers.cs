using System.Text.Json.Serialization;

namespace MyLibrary.Models
{
    public class Publishers
    {
        public int Id { get; set; } 
        public string PublisherName { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; }


    }
}
