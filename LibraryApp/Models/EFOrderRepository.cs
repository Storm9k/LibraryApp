using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private LibraryDBContext dbcontext;
        public EFOrderRepository(LibraryDBContext context)
        {
            dbcontext = context;
        }
        public IQueryable<Order> Orders => dbcontext.Orders.Include(o => o.Lines).ThenInclude(l => l.Book);
        public void SaveOrder (Order order)
        {
            dbcontext.AttachRange(order.Lines.Select(l => l.Book));
            if (order.ID == 0)
            {
                dbcontext.Orders.Add(order);
            }
            dbcontext.SaveChanges();
        }
    }
}
