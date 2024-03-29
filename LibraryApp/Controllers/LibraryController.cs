﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.Models.ViewModels;

namespace LibraryApp.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryDBContext context;
        public int PageSize = 3;

        public LibraryController(LibraryDBContext cnt)
        {
            context = cnt;
        }

        public IActionResult Index()
        {
            object connection = context.Database.ProviderName;

            return View(connection);

        }

        public IActionResult List(string genre = null, int page = 1)
        {
            BookList bookList = new BookList
            {
                Books = context.Books
                    .Where(g => genre == null || g.Genre.Name == genre)
                   .OrderBy(p => p.ID)
                   .Skip((page - 1) * PageSize)
                   .Take(PageSize),
                PagingInfo =  new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ? context.Books.Count() : context.Books.Where(e => e.Genre.Name == genre).Count(),
                    CurrentGenre = genre
                },
            };

            return View("List", bookList);
            //if (bookList.Books.Count() != 0)

            //else return NotFound("Объекты не найдены");
        }

        //public IActionResult ListWithPageSize(int page = 1)
        //{
        //    return View("List", context.Books.OrderBy(p => p.ID).Skip((page - 1) * PageSize).Take(PageSize));
        //}

        

    }
}
