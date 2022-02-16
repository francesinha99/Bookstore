using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };


            return View(x);
        }

    }
}
