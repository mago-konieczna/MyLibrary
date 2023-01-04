namespace MyLibrary.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Categories { get; set; }    
        public bool ForKids { get; set; }    
        public bool ForAdults { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }



    }
}
