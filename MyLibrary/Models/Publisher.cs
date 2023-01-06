namespace MyLibrary.Models
{
    public class Publisher
    {
        public int Id { get; set; } 
        public string PublisherName { get; set; }
        /* may add more properties in the future for example: Country, Adress, ContactEmail, ContactNumber */


        public List<Book> Books { get; set; }




    }
}
