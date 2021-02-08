using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LibraryApp.Models;
using System.Linq;
using System.Collections.Generic;
namespace LibraryApp.Components
{
    public class NavigationPanel : ViewComponent
    {
        private LibraryDBContext context;
        

        public NavigationPanel (LibraryDBContext cnt)
        {
            context = cnt;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = Request.Query["genre"];
            return View(context.Genres.Select(g => g).Distinct().OrderBy(g => g.Name));
        }
    }
}
