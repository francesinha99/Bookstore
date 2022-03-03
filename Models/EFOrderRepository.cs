using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private BookstoreContext context;

        public EFOrderRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Order => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));

            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
