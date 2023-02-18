﻿using System.Text.Json.Serialization;

namespace MyLibrary.Models
{
    public class Publishers
    {
        public int Id { get; set; } 
        public string PublisherName { get; set; }
        /* may add more properties in the future for example: Country, Adress, ContactEmail, ContactNumber */
        [JsonIgnore]
        public List<Book> Books { get; set; }


    }
}
