using System.Collections.Generic;

namespace LibraryApp.Models.ViewModels
{
    public class BookList
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
