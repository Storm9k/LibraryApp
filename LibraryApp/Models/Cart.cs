using System.Collections.Generic;
using System.Linq;

namespace LibraryApp.Models
{
    public class Cart
    {
        private List<CartLine> LineList = new List<CartLine>();
        public virtual void AddItem(Book book, int quantity)
        {
            CartLine Line = LineList.Where(b => b.Book.ID == book.ID).FirstOrDefault();
            if (Line == null)
            {
                LineList.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else Line.Quantity += quantity;
        }
        public virtual void RemoveLine(Book book)
        {
            LineList.RemoveAll(l => l.Book.ID == book.ID);
        }
        public virtual decimal ComputeTotalValue() => LineList.Sum(e => e.Book.Price * e.Quantity);
        public virtual void Clear() => LineList.Clear();
        public virtual IEnumerable<CartLine> Lines => LineList;
    }
    
    public class CartLine
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
