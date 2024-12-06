using IB_Company.Data;
using IB_Company.Models;
using IB_Company.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IB_Company.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                // проверив эти условия , можно считать сессия существует и можно получить все товары и показать их 
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

            }
            List<int> prodInCart = shoppingCartList.Select(i=>i.ProductId).ToList();
            IEnumerable<Product> prodList = _db.Product.Where(u => prodInCart.Contains(u.Id));
            
            return View(prodList);
        }
        public IActionResult Remove(int id)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                // проверив эти условия , можно считать сессия существует и можно получить все товары и показать их 
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);

            }
            shoppingCartList.Remove(shoppingCartList.FirstOrDefault(u => u.ProductId == id));
            HttpContext.Session.Set(WC.SessionCart , shoppingCartList);

            return RedirectToAction(nameof(Index));
        }
    }
}
