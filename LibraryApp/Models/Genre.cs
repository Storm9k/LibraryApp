using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
