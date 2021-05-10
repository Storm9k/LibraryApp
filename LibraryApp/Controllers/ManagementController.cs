using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class ManagementController : Controller
    {
        private LibraryDBContext DBContext;

        public ManagementController (LibraryDBContext context)
        {
            DBContext = context;
        }

        public IActionResult Index()
        {
            return View(DBContext.Books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = DBContext.Genres;
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int BookID)
        {
            ViewBag.Genres = DBContext.Genres;
            return View(DBContext.Books.FirstOrDefault(b => b.ID == BookID));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            book.Genre = DBContext.Genres.FirstOrDefault(g => g.ID == book.GenreID);

            if(ModelState.IsValid)
            {
                if (book.ID != 0) DBContext.Books.Update(book);
                else if (book.ID == 0) DBContext.Books.Add(book);
                DBContext.SaveChanges();
                TempData["message"] = $"Книга {book.Name} была сохранена";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int BookID)
        {
            Book book = DBContext.Books.FirstOrDefault(b => b.ID == BookID);
            if(book != null)
            {
                DBContext.Books.Remove(book);
                DBContext.SaveChanges();
                TempData["message"] = $"Книга {book.Name} был(а) удален(а)";
            }
            return RedirectToAction("Index");
        }
    }
}
