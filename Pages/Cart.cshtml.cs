using Computer_Craft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Computer_Craft.Pages
{
    public class CartModel : PageModel
    {
        public List<Cart> CartList = new List<Cart>();

        public void OnGet()
        {
            string referer = Request.Headers["referer"].ToString();
            var username = HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(referer) || string.IsNullOrEmpty(username))
            {
                Response.Redirect("/Login");
            }
            else
            {
                CartList = new DAL().GetAllCart(username);
            }
        }

        public void OnPostDelete(string id)
        {
            string username = HttpContext.Session.GetString("username");
            new DAL().DeleteCartItem(id, username);
            CartList = new DAL().GetAllCart(username);
        }

        public void OnPostConfirmOrder()
        {
            string username = HttpContext.Session.GetString("username");
            decimal totalPrice = Convert.ToDecimal(Request.Form["totalPrice"]);
            DateTime orderDate = DateTime.Now;


            CartList = new DAL().GetAllCart(username);

            foreach (var cartItem in CartList)
            {
                Console.WriteLine("quantity error");
                new DAL().UpdateProductQuantity(cartItem.SerialNumber, cartItem.CartQuantity);
            }
            new DAL().AddOrder(username, totalPrice, orderDate);
            CartList = new DAL().GetAllCart(username);

            Response.Redirect("/Invoice");
            
        }

        public void OnPostUpdateQuantity(string serial, int quantity)
        {
            string username = HttpContext.Session.GetString("username");
            new DAL().UpdateCartQuantity(username, serial, quantity);

            // Update the total price after changing the quantity
            decimal totalPrice = new DAL().CalculateTotalPrice(username);
            new DAL().UpdateCartTotalPrice(username, totalPrice);

            CartList = new DAL().GetAllCart(username);
        }
    }
}
