namespace MyLibrary.Models
{
    public class Publisher
    {
        public int Id { get; set; } 
        public string PublisherName { get; set; }    
        public string Country { get; set; }
        public string Adress { get; set; }

        //public string ContactEmail { get; set; }
        //public string ContactNumber { get; set; }


        public List<Book> Books { get; set; }




    }
}
