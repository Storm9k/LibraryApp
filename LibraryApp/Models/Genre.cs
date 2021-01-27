using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
