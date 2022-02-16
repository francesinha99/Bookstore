using System;
using System.Linq;

namespace Bookstore.Models
{
    public class EFBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
