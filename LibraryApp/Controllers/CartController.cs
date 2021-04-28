using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;
using LibraryApp.Infrastructure;
using LibraryApp.Models.ViewModels;

namespace LibraryApp.Controllers
{
    public class CartController : Controller
    {
        private LibraryDBContext context;
        private Cart cart;

        public CartController(LibraryDBContext cnt, Cart cartService)
        {
            context = cnt;
            cart = cartService;
        }

        [HttpGet]
        public IActionResult Index (string returnUrl)
        {
            return View("Index",new CartIndexViewModel
            {
                Cart = cart,
                ReturnURL = returnUrl
            });
        }

        [HttpPost]
        public IActionResult AddToCart (int bookid, string returnUrl)
        {
            Book book = context.Books.FirstOrDefault(b => b.ID == bookid);
            if (book != null)
            {
                cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", "Cart", new { returnUrl });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int book_id, string returnUrl)
        {
            Book book = context.Books.FirstOrDefault(b => b.ID == book_id);
            if (book != null)
            {
                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", "Cart", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}
        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}
    }
}
